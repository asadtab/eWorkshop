using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class RadniZadatakUredjajVM
    {
        public int Id { get; set; }

        public int RadniZadatakId { get; set; }

        public int UredjajId { get; set; }

        public string Napomena { get; set; }

        public int KorisnikId { get; set; }

        public  KorisniciVM Korisnik { get; set; }

        public  RadniZadatakVM RadniZadatak { get; set; } 

        public  UredjajVM Uredjaj { get; set; }

        public string IdTip { get { return UredjajId + " - " + Uredjaj.Tip.OpisNaziv; } set { } } 
    }
}
