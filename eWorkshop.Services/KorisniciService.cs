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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace eWorkshop.Services
{
    public class KorisniciService : BaseCRUDService<KorisniciVM, KorisniciSearchObject, Korisnici, KorisniciInsertRequest, KorisniciUpdateRequest>, IKorisniciService
    {
        private readonly UserManager<Korisnici> _userManager;
        private readonly RoleManager<Uloge> _roleManager;
        public KorisniciService(_190128Context context, IMapper mapper, RoleManager<Uloge> roleManager, UserManager<Korisnici> userManager) : base(context, mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<KorisniciVM> Register(KorisniciInsertRequest request)
        {
            if (request == null)
                throw new ArgumentException("Zahtjev ne može biti prazan.");

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Korisnik sa ovom email adresom već postoji.");

            var user = CreateUser();

            user.UserName = request.Ime.ToLower() + "." + request.Prezime.ToLower();
            user.Email = request.Email;
            user.Ime = request.Ime;
            user.Prezime = request.Prezime;
            user.TwoFactorEnabled = false;
            user.PhoneNumberConfirmed = false;
            user.LockoutEnabled = false;
            user.AccessFailedCount = 100;
            user.Status = request.Status;
            user.RadnaJedinica = request.RadnaJedinica;
            user.EmailConfirmed = true;

            if (request.Uloge == null || !request.Uloge.Any())
                throw new ArgumentException("Lista uloga ne smije biti prazna.");

            foreach (var uloga in request.Uloge)
            {
                var exists = await _roleManager.RoleExistsAsync(uloga);
                if (!exists)
                    throw new ArgumentException($"Uloga '{uloga}' ne postoji u bazi podataka.");
            }

            var result = await _userManager.CreateAsync(user, request.PasswordHash);
            if (!result.Succeeded)
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                throw new Exception($"Greška prilikom kreiranja korisnika: {errors}");
            }

            var roleResult = await _userManager.AddToRolesAsync(user, request.Uloge);
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                var errors = string.Join(" ", roleResult.Errors.Select(e => e.Description));
                throw new Exception($"Greška pri dodavanju uloga: {errors}");
            }

            var claims = new List<Claim>
    {
        new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
        new Claim(JwtClaimTypes.Name, $"{user.Ime} {user.Prezime}"),
        new Claim(JwtClaimTypes.Email, user.Email),
        new Claim(JwtClaimTypes.Id, user.Id.ToString())
    };

            foreach (var uloga in request.Uloge)
            {
                claims.Add(new Claim(ClaimTypes.Role, uloga));
            }

            await _userManager.AddClaimsAsync(user, claims);

            // Creating a view model to return
            var korisnikVM = new KorisniciVM
            {
                UserName = user.UserName,
                Ime = user.Ime,
                Prezime = user.Prezime,
                Email = user.Email,
                Status = true,
                RadnaJedinica = user.RadnaJedinica,
                Uloge = request.Uloge
            };

            return korisnikVM;
        }


        public async Task<KorisniciVM?> UpdatePassword(PromjeniPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return null; // just return null for not found

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(" ", result.Errors.Select(e => e.Description)));
            }

            var userVM = Get(new KorisniciSearchObject { KorisnikID = user.Id });
            return userVM.FirstOrDefault();
        }


        private Korisnici CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Korisnici>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Korisnici)}'. " +
                    $"Ensure that '{nameof(Korisnici)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
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
