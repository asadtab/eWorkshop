using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class RadniZadatakUredjajData
    {
        public static void SeedData(this EntityTypeBuilder<RadniZadatakUredjaj> entity)
        {
            entity.HasData(new RadniZadatakUredjaj() { Id = 1, KorisnikId = 1, RadniZadatakId = 1, UredjajId = 189},
                new RadniZadatakUredjaj() { Id = 2, KorisnikId = 1, RadniZadatakId = 1, UredjajId = 190 },
                new RadniZadatakUredjaj() { Id = 3, KorisnikId = 2, RadniZadatakId = 1, UredjajId = 192 },
                new RadniZadatakUredjaj() { Id = 4, KorisnikId = 2, RadniZadatakId = 1, UredjajId = 193 },
                new RadniZadatakUredjaj() { Id = 5, KorisnikId = 1, RadniZadatakId = 1, UredjajId = 194 });
        }
    }
}
