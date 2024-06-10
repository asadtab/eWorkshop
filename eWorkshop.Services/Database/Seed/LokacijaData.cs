using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class LokacijaData
    {
        public static void SeedData(this EntityTypeBuilder<Lokacija> entity)
        {
            entity.HasData(new Lokacija {LokacijaId = 1, Naziv = "Sarajevo" }, new Lokacija { LokacijaId = 2, Naziv = "Zenica" }, new Lokacija {LokacijaId = 3,  Naziv = "Mostar" });
        }
    }
}
