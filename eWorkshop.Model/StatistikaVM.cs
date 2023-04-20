using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class StatistikaVM
    {
        //radni zadaci
        public int AktivniRadniZadaci { get; set; } = 0;
        public int RadniZadaciUkupno { get; set; } = 0;
        public int FakturisaniRadniZadaci { get; set; } = 0;
        public int ZavrseniRadniZadaci { get; set; } = 0;
        public int NeaktivniRadniZadaci { get; set; } = 0;

        //uredjaji
        public int ServisiraniUredjaji { get; set; } = 0;
        public int AktivniUredjaji { get; set; } = 0;
        public int NeaktivniUredjaji { get; set; } = 0;
        public int PoslaniUredjaji { get; set; } = 0;
        public int UredjajiUkupno { get; set; } = 0;
        public int SpremniUredjaji { get; set; } = 0;
        public int RezervniDijeloviUredjaji { get; set; } = 0;
        public int RadniZadaciUredjaji { get; set; } = 0;

        //korisnici
        public int KorisniciUkupno { get; set; }
    }
}
