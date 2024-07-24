using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class TipUredjajaData
    {
        public static void SeedData(this EntityTypeBuilder<TipUredjaja> entity)
        {
            entity.HasData(new TipUredjaja { TipUredjajaId = 1, Naziv = "KRS", Opis = "Skretnička relejna grupa" },
    new TipUredjaja { TipUredjajaId = 2, Naziv = "RGS", Opis = "Signalna relejna grupa" },
    new TipUredjaja { TipUredjajaId = 3, Naziv = "RKG", Opis = "Relejna kontrolna grupa" });
        }
        }
}
