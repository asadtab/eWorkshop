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

        public string KorisnikId { get; set; }

        public  KorisniciVM Korisnik { get; set; }

        public  RadniZadatakVM RadniZadatak { get; set; }

        public UredjajVM Uredjaj { get; set; } = new UredjajVM();

        public string TipNaziv { get { return Uredjaj.Tip.Naziv; } set { } }
        public string TipOpis { get { return Uredjaj.Tip.Opis; } set { } }
        public string TipOpisNaziv { get { return Uredjaj.Tip.OpisNaziv; } set { } }
        public string UredjajKoda { get { return Uredjaj.Koda; } set { } }
        public string UredjajSerijskiBroj { get { return Uredjaj.SerijskiBroj; } set { } }

        public string IdTip { get { return UredjajId + " - " + Uredjaj.Tip.OpisNaziv; } set { } } 
    }
}
