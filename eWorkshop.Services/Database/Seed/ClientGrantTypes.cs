using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ClientGrantTypes
    {
        public static void SeedData(this EntityTypeBuilder<ClientGrantType> entity)
        {
            entity.HasData(new ClientGrantType() { GrantType = "client_credentials", ClientId = 1, Id = 1 });
        }
        }
}
