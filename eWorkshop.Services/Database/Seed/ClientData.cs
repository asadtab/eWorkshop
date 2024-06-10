using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ClientData
    {
        public static void SeedData(this EntityTypeBuilder<Client> entity)
        {
            entity.HasData(new Client() { Id = 1, Enabled = true, ClientId = "flutter", ProtocolType = "x", RequireClientSecret = true, ClientName = "Flutter", ClientUri = "uri", AllowOfflineAccess = true });
        }
        }
}
