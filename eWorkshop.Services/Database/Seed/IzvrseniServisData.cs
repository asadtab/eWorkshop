using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class IzvrseniServisData
    {
        public static void SeedData(this EntityTypeBuilder<IzvrseniServi> entity)
        {
            entity.HasData(new IzvrseniServi() { IzvrseniServisId = 1, Datum = DateTime.UtcNow, KomponentaId = 1, ServisId = 1},
                new IzvrseniServi() { IzvrseniServisId = 2, Datum = DateTime.UtcNow, KomponentaId = 2, ServisId = 1 }, new IzvrseniServi() { IzvrseniServisId = 5, Datum = DateTime.UtcNow, KomponentaId = 3, ServisId = 1 }
                , new IzvrseniServi() { IzvrseniServisId = 3, Datum = DateTime.UtcNow, KomponentaId = 1, ServisId = 2 },
                new IzvrseniServi() { IzvrseniServisId = 4, Datum = DateTime.UtcNow, KomponentaId = 3, ServisId = 2 });
        }
        }
}
