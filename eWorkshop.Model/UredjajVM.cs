using eWorkshop.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Text;


namespace eWorkshop.Model
{
    public class UredjajVM
    {
        public int UredjajId { get; set; }

        public bool isDeleted { get; set; }
        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public string GodinaIzvedbe { get; set; }

        public bool isSelected { get; set; }

        public string Status { get; set; }
        //{ return StatusHelper.ProvjeraStatusa(Status, StatusHelper.nizNaziv, StatusHelper.nizOpis); }
        //public int LokacijaId { get; set; }

        public TipUredjajaVM Tip { get; set; } = new TipUredjajaVM();
        public string TipNaziv { get { return Tip?.Naziv; } set { } }
        public string TipOpis { get { return Tip?.Opis; } set { } }
        public string TipOpisNaziv { get { return Tip?.OpisNaziv; } set { } }

        public string IdTip { get { return UredjajId + " - " + TipOpisNaziv; } set { } }
        public LokacijaVM Lokacija { get; set; } = new LokacijaVM();

        public string LokacijaNaziv { get { return Lokacija?.Naziv; } set { } }

    }
}
