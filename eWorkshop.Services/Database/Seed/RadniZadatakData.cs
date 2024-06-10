using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database.Seed
{
    public static class RadniZadatakData
    {
        public static void SeedData(this EntityTypeBuilder<RadniZadatak> entity)
        {
            entity.HasData(new RadniZadatak() {RadniZadatakId = 1, Datum = DateTime.Now, Naziv = "Mostar", StateMachine = "active" });
        }
    }
}
