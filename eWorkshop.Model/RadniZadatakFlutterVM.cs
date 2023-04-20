using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class RadniZadatakFlutterVM
    {
        public int RadniZadatakId { get; set; }
        public int UredjajId{ get; set; }
        public string RadniZadatakNaziv { get; set; }   
        public string RadniZadatakStatus { get; set; }   
        public string RadniZadatakDatum { get; set; }   
        public string Koda { get; set; }   
        public string SerijskiBroj { get; set; }   
        public string UredjajStatus { get; set; }   
        public string UredjajDatumIzvedbe { get; set; }   
        public string TipNaziv { get; set; }   
        public string TipOpis { get; set; }   
        public string Lokacija { get; set; }
        public double Progres { get; set; }
    }
}
