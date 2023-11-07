//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using eWorkshop.Model;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UlogeController: ControllerBase
    {
        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> RoleManager;

        public UlogeController(RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpPost]
        public async Task<AspNetRoleVM> CreateRole([FromBody] string roleName)
        {
            var roleCheck = await RoleManager.FindByNameAsync(roleName);

            if(roleCheck is not null)
            {
                return null;
            }

            var role = new Microsoft.AspNetCore.Identity.IdentityRole(roleName);

            var result = await RoleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return null;
            }

            var uloga = new AspNetRoleVM();

            uloga.Id = role.Id;
            uloga.Name = role.Name;
            uloga.NormalizedName = role.NormalizedName;

            return uloga;
        }
    }
}
