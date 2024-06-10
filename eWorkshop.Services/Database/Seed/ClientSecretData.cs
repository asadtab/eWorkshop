using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ClientSecretData
    {
        public static void SeedData(this EntityTypeBuilder<ClientSecret> entity)
        {
            entity.HasData(new ClientSecret() { Id = 1, ClientId = 1 , Description = "Aplikacija", Value = "flutter", Expiration = DateTime.Parse("2025-02-04 09:39:35.1090000"), Type = "app", Created = DateTime.Now});
        }
        }
}
