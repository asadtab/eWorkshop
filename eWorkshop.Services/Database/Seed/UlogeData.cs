using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class UlogeData
    {
        public static void SeedData(this EntityTypeBuilder<Uloge> entity)
        {
            entity.HasData(new Uloge { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" }, new Uloge {Id =2, Name = "Serviser", NormalizedName = "SERVISER" });
        }
    }
}
