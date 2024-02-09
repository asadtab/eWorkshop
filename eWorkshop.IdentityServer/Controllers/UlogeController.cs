//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using eWorkshop.Model;
using eWorkshop.Services.Database;

namespace eWorkshop.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]/ids")]
    public class UlogeController: ControllerBase
    {
        private readonly RoleManager<Uloge> RoleManager;

        public UlogeController(RoleManager<Uloge> roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var roleCheck = await RoleManager.FindByNameAsync(roleName);

            if(roleCheck is not null)
            {
                return BadRequest("Uloga s tim imenom već postoji.");
            }

            //var role = new Microsoft.AspNetCore.Identity.IdentityRole(roleName);

            var role = new Uloge();
            role.Name = roleName;

            var result = await RoleManager.CreateAsync(role);
            

            if (!result.Succeeded)
            {
                return BadRequest("Uloga nije dodana.");
            }

            return Ok("Uloga " + role.NormalizedName + ", je uspješno dodana.");
        }
    }
}
