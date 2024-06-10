using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ClientScopeData
    {
        public static void SeedData(this EntityTypeBuilder<ClientScope> entity)
        {
            entity.HasData(new ClientScope() { Id = 1, ClientId = 1, Scope = "weatherapi.read" },
                new ClientScope() { Id = 2, ClientId = 1, Scope = "weatherapi.write" });
        }
        }
}
