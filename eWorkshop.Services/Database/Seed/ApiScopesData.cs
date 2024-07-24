using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ApiScopesData
    {
        public static void SeedData(this EntityTypeBuilder<ApiScope> entity)
        {
            entity.HasData(new ApiScope() { Id = 1, Enabled = true, Name = "profile", DisplayName = "Pristup", Description = "Pristup informacijama o korisniku", Created = DateTime.Now },
                new ApiScope() { Id = 2, Enabled = true, Name = "email", DisplayName = "Email", Description = "Pristup e-mail adresama korisnika", Created = DateTime.Now },
                new ApiScope() { Id = 3, Enabled = true, Name = "openid", DisplayName = "OpenID", Description = "Potreban je OpenID Connect, zahtijeva osnovne informacije o korisniku", Created = DateTime.Now });
        }
        }
}
