using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class KomponenteData
    {
        public static void SeedData(this EntityTypeBuilder<Komponente> entity)
        {
            entity.HasData(new Komponente() { KomponentaId = 1, Naziv = "Otpornik", Vrijednost = "100Ω" },
                new Komponente() { KomponentaId = 2, Naziv = "Relej WT", Tip = "7/VFV 190a" },
                new Komponente() { KomponentaId = 3, Naziv = "Relej FV", Tip = "8/WRW 170a" },
                new Komponente() { KomponentaId = 4, Naziv = "Kondenzator", Vrijednost = "200pF" });
        }

        }
}
