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
using IdentityModel;

namespace eWorkshop.Services
{
    public class KorisniciService : BaseCRUDService<KorisniciVM, KorisniciSearchObject, Korisnici, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        public KorisniciService(_190128Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override IQueryable<Korisnici> AddInclude(IQueryable<Korisnici> query, KorisniciSearchObject search = null)
        {
            var uloge = Context.KorisniciUloge.ToList();

            return base.AddInclude(query, search);
        }

        public override IEnumerable<KorisniciVM> Get(KorisniciSearchObject search = null)
        {
            var korisnici = base.Get(search).ToList(); 

            var ulogeKorisnici = Context.KorisniciUloge.ToList();
            var uloge = Context.Uloge.ToList();

            foreach (var user in korisnici)
            {
                var roles = ulogeKorisnici
                    .Where(x => x.UserId == user.Id)
                    .Select(x => x.RoleId)
                    .ToList();

                var userRoles = uloge
                    .Where(x => roles.Contains(x.Id))
                    .Select(x => x.Name)
                    .ToList();

                user.Uloge = userRoles;
            }

            return korisnici;
        }


        public override KorisniciVM GetById(int id)
        {

            var korisnikUloge = Context.KorisniciUloge.Where(x => x.UserId == id).ToList();

            var uloge = Context.Uloge.ToList();

            List<string> nazivUloge = new List<string>();

            foreach (var uloga in korisnikUloge)
            {
                foreach (var role in uloge)
                {
                    if(uloga.RoleId == role.Id)
                    {
                        nazivUloge.Add(role.Name);
                    }
                }
            }

            var korisnik = base.GetById(id);

            korisnik.Uloge = nazivUloge;

            return korisnik;
        }


        public override IQueryable<Korisnici> AddFilter(IQueryable<Korisnici> query, KorisniciSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search.KorisnickoIme))
                return filteredQuery = filteredQuery.Where(x => x.UserName.Contains( search.KorisnickoIme));

            if (!string.IsNullOrWhiteSpace(search.ImePrezime))
                return filteredQuery = filteredQuery
                    .Where(x => 
                     (x.Ime + " " + x.Prezime).Contains(search.ImePrezime) 
                    || (x.Prezime + " " + x.Ime).Contains(search.ImePrezime));

            if (search.KorisnikID != 0 && search.KorisnikID != null)
            {
                return filteredQuery = filteredQuery.Where(x => x.Id == search.KorisnikID);
            }

            return filteredQuery;
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
