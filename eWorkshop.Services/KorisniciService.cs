using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Azure.Core;
using System.Net.Http.Headers;
using System.Web;
using System.Security.Principal;

namespace eWorkshop.Services
{
    public class KorisniciService : BaseCRUDService<KorisniciVM, KorisniciSearchObject, Korisnici, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        public KorisniciService(_190128Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IQueryable<Korisnici> AddFilter(IQueryable<Korisnici> query, KorisniciSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search.KorisnickoIme))
                return filteredQuery = filteredQuery.Where(x => x.KorisnickoIme == search.KorisnickoIme);

            if (!string.IsNullOrWhiteSpace(search.ImePrezime))
                return filteredQuery = filteredQuery
                    .Where(x => 
                     (x.Ime + " " + x.Prezime).Contains(search.ImePrezime) 
                    || (x.Prezime + " " + x.Ime).Contains(search.ImePrezime));

            return filteredQuery;
        }

        public override IQueryable<Korisnici> AddInclude(IQueryable<Korisnici> query, KorisniciSearchObject search = null)
        {
            if (search.IncludeUloge)
            {
                query = query.Include("KorisniciUloges.Uloga");
            }

            return query;
        }

        public KorisniciVM Login(string username, string password)
        {
            var entity = Context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            if(entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if(hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<KorisniciVM>(entity);
        }

        public override void BeforeInsert(KorisniciInsertRequest insert, Korisnici entity)
        {
            var salt = GenerateSalt();
            entity.LozinkaSalt = salt;
            entity.LozinkaHash = GenerateHash(salt, insert.Password);
            base.BeforeInsert(insert, entity);
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }



        }
}
