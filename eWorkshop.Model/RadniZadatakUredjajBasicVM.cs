using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class RadniZadatakUredjajBasicVM
    {
        public int Id { get; set; }

        public int RadniZadatakId { get; set; }

        public int UredjajId { get; set; }

        public string Napomena { get; set; }

        public string KorisnikId { get; set; }

        public KorisniciVM Korisnik { get; set; }

        public RadniZadatakVM RadniZadatak { get; set; }

        public UredjajVM Uredjaj { get; set; }
    }
}
