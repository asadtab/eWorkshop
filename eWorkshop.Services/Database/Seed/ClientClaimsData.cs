using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ClientClaimsData
    {
        public static void SeedData(this EntityTypeBuilder<ClientClaim> entity)
        {
            entity.HasData(new ClientClaim() { Id = 1, ClientId = 1, Value = "email", Type = "Email"},
                new ClientClaim() { Id = 2, ClientId = 1, Value = "name", Type = "Name" },
                new ClientClaim() { Id = 3, ClientId = 1, Value = "id", Type = "Id" },
                new ClientClaim() { Id = 4, ClientId = 1, Value = "username", Type = "Username" });
        }
        }
}
