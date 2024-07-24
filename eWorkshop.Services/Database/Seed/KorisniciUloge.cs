using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class KorisniciUloge
    {
        public static void SeedData(this EntityTypeBuilder<Microsoft.AspNetCore.Identity.IdentityUserRole<int>> entity)
        {
            entity.HasData(new Microsoft.AspNetCore.Identity.IdentityUserRole<int>() { RoleId = 1, UserId = 1},
                new Microsoft.AspNetCore.Identity.IdentityUserRole<int>() { RoleId = 2, UserId = 2 });
        }
    }
}
