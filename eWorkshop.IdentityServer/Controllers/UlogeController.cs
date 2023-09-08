//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var roleCheck = await RoleManager.FindByNameAsync(roleName);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Naziv uloge ne može biti prazan.");
            }

            if(roleCheck is not null)
            {
                return BadRequest($"Uloga sa nazivom '{roleName}' postoji.");
            }

            var role = new Microsoft.AspNetCore.Identity.IdentityRole(roleName);

            var result = await RoleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok($"Role '{roleName}' created successfully.");
            }

            return BadRequest("Role creation failed.");
        }
    }
}
