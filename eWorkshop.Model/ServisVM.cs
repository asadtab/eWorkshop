using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ServisVM
    {
        public int ServisId { get; set; }

        public string Napomena { get; set; }

        public int KorisnikId { get; set; }

        public KorisniciVM Korisnik { get; set; } = new KorisniciVM();
        public int UredjajId { get; set; }

        //public int RadniZadatakId { get; set; }

        public DateTime? Datum { get; set; } = new DateTime();

       // public string DatumServisa { get { return DatumServisa; } set { DatumServisa = Datum.Value.Day.ToString() + "." + Datum.Value.Month.ToString() + "." + Datum.Value.Year.ToString(); } }
        //{ get { return Datum.Value.Day.ToString() + "." + Datum.Value.Month.ToString() + "." + Datum.Value.Year.ToString(); } set { } }


        public RadniZadatakVM RadniZadatak { get; set; } = new RadniZadatakVM();

        public UredjajVM Uredjaj { get; set; } = new UredjajVM();
    }
}
