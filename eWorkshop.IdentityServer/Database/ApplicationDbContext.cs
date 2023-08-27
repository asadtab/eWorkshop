using eWorkshop.Services.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eWorkshop.IdentityServer.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        /// <summary>
        /// Ovo je implementacija databse contexta za identity server
        /// </summary>
        /// <param name="options"></param>
        /// 


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
    }
}
