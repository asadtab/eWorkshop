using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ApiResourcesData
    {
        public static void SeedData(this EntityTypeBuilder<ApiResource> entity)
        {
            entity.HasData(new ApiResource() { Id = 1, Created = DateTime.Now, Enabled = true, Name = "api", DisplayName = "api", Description = "Api", ShowInDiscoveryDocument = true, });
        }
        }
}
