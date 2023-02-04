using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class UredjajVM
    {
        public int UredjajId { get; set; }


        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public string DatumIzvedbe { get; set; }

        public string Status { get; set; }

        //public int LokacijaId { get; set; }

        public TipUredjajaVM Tip { get; set; } = new TipUredjajaVM();
        public string TipOpisNaziv { get { return Tip?.OpisNaziv; } set { } }

        public string IdTip { get { return UredjajId + " - " + TipOpisNaziv; } set { } }
        public LokacijaVM Lokacija { get; set; } = new LokacijaVM();

        //public string LokacijaNaziv { get { return Lokacija.Naziv; } set { } }

    }
}
