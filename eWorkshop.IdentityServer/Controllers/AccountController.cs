using AutoMapper;

using eWorkshop.Model;
using eWorkshop.Model.Requests;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Duende.IdentityServer;
using eWorkshop.Services.Database;
using Duende.IdentityServer.Stores;
using static Duende.IdentityServer.Models.IdentityResources;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> Logger;
        private readonly IConfiguration Configuration;
        private readonly SignInManager<Korisnici> _signInManager;
        private readonly UserManager<Korisnici> _userManager;
        private readonly IUserStore<Korisnici> _userStore;
        private readonly IUserRoleStore<KorisniciUloge> _userRoleStore;
        private readonly IRoleStore<Uloge> _roleStore;
        private readonly IUserEmailStore<Korisnici> _emailStore;
        private readonly IdentityServerTools _tools;
        private readonly IClientStore _clientStore;
        private readonly _190128Context Context;

        private IMapper Mapper { get; }

        public AccountController(
            _190128Context context,
            IClientStore clientStore,
            IRoleStore<Uloge> roleStore,
            UserManager<Korisnici> userManager,
            IUserStore<Korisnici> userStore,
            SignInManager<Korisnici> signInManager,
            IConfiguration configuration,
            ILogger<AccountController> logger,
            IdentityServerTools tools
            )
        {
            Context = context;
            _clientStore = clientStore;
             _roleStore = roleStore;
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            Configuration = configuration;
            Logger = logger;
            _tools = tools;
        }

        [HttpPost]
        public async Task<IActionResult> Register(KorisniciInsertRequest request)
        {
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

            var email = await _userManager.FindByEmailAsync(user.Email);

            if(email != null)
            {
                return BadRequest("Email adresa nije dostupna");
            }

            var result = await _userManager.CreateAsync(user, request.PasswordHash);
            
            


            var cancToken = CancellationToken.None;

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;

                if (user == null)
                {
                    return BadRequest("User je null");
                }

                if (request.Uloge == null)
                {
                    return BadRequest("Uloga je null");
                }

                var uloge = await _userManager.GetRolesAsync(user);

                

                var ulogetemp =  await _userManager?.AddToRolesAsync(user, request.Uloge);
  

                var claims = new List<Claim>
             {
              new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
              new Claim(JwtClaimTypes.Name, user.Ime + " " + user.Prezime),
              new Claim(JwtClaimTypes.Email, user.Email),
              new Claim(JwtClaimTypes.Id, user.Id.ToString()),
            };

                foreach (var x in uloge)
                {
                    claims.Add(new Claim(ClaimTypes.Role, x));
                }
                 

                await _userManager.AddClaimsAsync(user, claims);
                
            }

            if (result.Errors.ToList().Count > 0)
            {
                var errorMsg = string.Join(" ", result.Errors.Select(x => x.Description));

                throw new Exception(errorMsg);

            }

            var korisnik = new KorisniciVM();
            
            return Ok();
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

        [HttpGet]
        public async Task<IEnumerable<KorisniciVM>> GetUsersAsync()
        {
            IQueryable<Korisnici> query = _userManager.Users;

            var users = await query.ToListAsync();
            

            var model = Mapper.Map<List<KorisniciVM>>(users);

            return model;
        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var login = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!login.Succeeded)
            {
                throw new Exception("Logiranje nije uspjelo");
            }

            var uloge = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
             {
              new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
              new Claim(JwtClaimTypes.Name, user.Ime + " " + user.Prezime),
              new Claim(JwtClaimTypes.Email, user.Email),
              new Claim(JwtClaimTypes.Id, user.Id.ToString()),
            };

            foreach (var x in uloge)
            {
                claims.Add(new Claim(ClaimTypes.Role, x));
            }

            var client = Context.Clients.Where(x => x.ClientId == "flutter").FirstOrDefault();
            var scopes = Context.ClientScopes.Where(x => x.ClientId == client.Id).Select(x => x.Scope).ToList();


            var token = await _tools.IssueClientJwtAsync(clientId: client.ClientId, lifetime: 3600, scopes: scopes, audiences: new[] { "api" }, additionalClaims: claims);
           
            return Ok(token);
        }
    }
}
