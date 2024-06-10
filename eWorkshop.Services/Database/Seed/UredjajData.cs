using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class UredjajData
    {
        public static void SeedData(this EntityTypeBuilder<Uredjaj> entity)
        {
            entity.HasData(new Uredjaj { UredjajId = 189, TipId = 2, Koda = "465-406-503", SerijskiBroj = "4810 AS", GodinaIzvedbe = "1987", Status = "idle", LokacijaId = 1, IsDeleted = false},
    new Uredjaj { UredjajId = 190, TipId = 1, Koda = "13E7283-1", SerijskiBroj = "62 66", GodinaIzvedbe = "1987",    Status = "idle"    ,  LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 191, TipId = 1, Koda = "465-406-503", SerijskiBroj = "1188 ES", GodinaIzvedbe = "1987",Status = "active"  , LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 192, TipId = 1, Koda = "465-406-503", SerijskiBroj = "22 33", GodinaIzvedbe = "1987",  Status = "fix"     ,    LokacijaId = 3, IsDeleted = false },
    new Uredjaj { UredjajId = 193, TipId = 1, Koda = "465-406-503", SerijskiBroj = "88 99", GodinaIzvedbe = "1987",  Status = "task"    ,   LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 194, TipId = 1, Koda = "465-204-000", SerijskiBroj = "7697 OS", GodinaIzvedbe = "1987",Status = "fix"    ,    LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 195, TipId = 2, Koda = "465-417-500", SerijskiBroj = "7034 OS", GodinaIzvedbe = "1987",Status = "ready"    ,  LokacijaId = 3, IsDeleted = false    },
    new Uredjaj { UredjajId = 196, TipId = 3, Koda = "465-436-701", SerijskiBroj = "32/87", GodinaIzvedbe = "1987",  Status = "out"    ,    LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 197, TipId = 2, Koda = "471-008-503", SerijskiBroj = "1712 MS", GodinaIzvedbe = "1987",Status = "parts"   ,   LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 198, TipId = 2, Koda = "471-008-504", SerijskiBroj = "197/19", GodinaIzvedbe = "1987", Status = "idle"  , LokacijaId = 3, IsDeleted = false },
    new Uredjaj { UredjajId = 199, TipId = 3, Koda = "465-406-503", SerijskiBroj = "174 AS", GodinaIzvedbe = "1987", Status = "active", LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 200, TipId = 2, Koda = "465-406-800", SerijskiBroj = "2413 NS", GodinaIzvedbe = "1987",Status = "fix"   , LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 201, TipId = 2, Koda = "465-406-800", SerijskiBroj = "2423 NS", GodinaIzvedbe = "1987",Status = "task"  , LokacijaId = 3, IsDeleted = false },
    new Uredjaj { UredjajId = 202, TipId = 3, Koda = "465-436-700", SerijskiBroj = "231181", GodinaIzvedbe = "1987", Status = "fix"   , LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 203, TipId = 3, Koda = "465-436-701", SerijskiBroj = "2566 FS", GodinaIzvedbe = "1987",Status = "ready" , LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 204, TipId = 3, Koda = "465-436-701", SerijskiBroj = "2676 FS", GodinaIzvedbe = "1987",Status = "out"   , LokacijaId = 3, IsDeleted = false },
    new Uredjaj { UredjajId = 205, TipId = 2, Koda = "13E7234-2", SerijskiBroj = "3/66", GodinaIzvedbe = "1987",     Status = "parts", LokacijaId = 1, IsDeleted = false },
    new Uredjaj { UredjajId = 206, TipId = 3, Koda = "471-008-504", SerijskiBroj = "23040", GodinaIzvedbe = "1987",   Status = "ready", LokacijaId = 2, IsDeleted = false },
    new Uredjaj { UredjajId = 207, TipId = 3, Koda = "471-008-504", SerijskiBroj = "0105051", GodinaIzvedbe = "1987", Status = "out"  , LokacijaId = 3, IsDeleted = false },
    new Uredjaj { UredjajId = 208, TipId = 3, Koda = "471-008-504", SerijskiBroj = "8723069", GodinaIzvedbe = "1987" ,Status = "parts", LokacijaId = 1, IsDeleted = false });
        }
    }
}
