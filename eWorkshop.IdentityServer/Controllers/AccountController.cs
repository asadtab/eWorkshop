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
using Microsoft.AspNetCore.Authorization;

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
            //IClientStore clientStore,
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
            //_clientStore = clientStore;
             _roleStore = roleStore;
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            Configuration = configuration;
            Logger = logger;
            _tools = tools;
        }

        
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Korisnik ne postoji.");
                return BadRequest("Korisnik ne postoji.");
            }

            /*var login = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!login.Succeeded)
            {
                throw new Exception("Logiranje nije uspjelo");
            }*/

            var passwordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordValid)
            {
                return BadRequest("Pogrešno korisničko ime ili lozinka.");
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

            if (client == null)
            {
                return BadRequest("Klijent 'flutter' ne postoji u bazi.");
            }

            var scopes = Context.ClientScopes.Where(x => x.ClientId == client.Id).Select(x => x.Scope).ToList();


            var token = await _tools.IssueClientJwtAsync(clientId: client.ClientId, lifetime: 2592000, scopes: scopes, audiences: new[] { "api" }, additionalClaims: claims);
           
            return Ok(token);
        }
    }
}
