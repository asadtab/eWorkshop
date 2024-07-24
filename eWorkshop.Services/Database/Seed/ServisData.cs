using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class ServisData
    {
        public static void SeedData(this EntityTypeBuilder<Servi> entity)
        {
            entity.HasData(new Servi() { ServisId = 1, Datum = DateTime.Now, UredjajId = 189, KorisnikId = 1, RadniZadatakId = 1},
                new Servi() { ServisId = 2, Datum = DateTime.Now, UredjajId = 190, KorisnikId = 1, RadniZadatakId = 1 },
                new Servi() { ServisId = 3, Datum = DateTime.Now, UredjajId = 191, KorisnikId = 2, RadniZadatakId = 1 },
                new Servi() { ServisId = 4, Datum = DateTime.Now, UredjajId = 192, KorisnikId = 2, RadniZadatakId = 1 },
                new Servi() { ServisId = 5, Datum = DateTime.Now, UredjajId = 193, KorisnikId = 1, RadniZadatakId = 1 });
        }
    }
}