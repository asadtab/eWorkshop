using AutoMapper;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer.Test;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        /*private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;*/
        private IMapper Mapper { get; }

        public AccountController(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _userStore = userStore;
            //_emailStore = GetEmailStore();
            _signInManager = signInManager;
            Mapper = mapper;
           
        }

        [HttpPost]
        public async Task<IActionResult> Register(AspNetUserInsertRequest request)
        {
            var pass = Encoding.UTF8.GetString(Convert.FromBase64String(request.PasswordHash)); 

            var user = CreateUser();

            user.UserName = request.UserName;
            user.Email = request.Email;
            user.NormalizedUserName = request.UserName.ToString().ToUpper();

            var result = await _userManager.CreateAsync(user, pass);

            if (result.Succeeded)
            {

                user.EmailConfirmed = true;


                var ulogeResult = await _userManager.AddToRolesAsync(user, request.Roles);
                
            }

            if (result.Errors.ToList().Count > 0)
            {
                var errorMsg = string.Join(" ", result.Errors.Select(x => x.Description));

                throw new Exception(errorMsg);

            }

            return Ok("Uspješno je dodan korisnik.");
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<AspNetUserVM>> GetUsersAsync()
        {
            // Start with a base query
            IQueryable<IdentityUser> query = _userManager.Users;

            // Apply search criteria
            /*if (!string.IsNullOrEmpty(search.UserName))
            {
                query = query.Where(u => u.UserName.Contains(search.UserName));
            }

            if (!string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(u => u.Email.Contains(search.Email));
            }*/

            // Add more criteria as needed

            // Execute the query and return results
            var users = await query.ToListAsync();
            

            var model = Mapper.Map<List<AspNetUserVM>>(users);

            return model;
        }
    }
}
