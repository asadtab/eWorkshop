using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class IzvrseniServisIzvjestajVM
    {
        public int RadniZadatakId { get; set; }
        public DateTime DatumPrijema { get; set; }
        public DateTime DatumServisiranja { get; set; }
        public string BrojRadnogNaloga { get; set; }
        public string KontoBroj { get; set; }
        public int EvBroj { get; set; }
        public string TipUredjaja { get; set; }
        public string Koda{ get; set; }
        public string SerijskiBroj{ get; set; }
        public string OpisKodPrijema { get; set; }
        public string OpisAktivnostiServisiranja { get; set; }
        public string ServisiraoIIspitao { get; set; }
        public string Odobrio { get; set; }
        public string Nadzor { get; set; }
        public int BrojServisa { get; set; }
        public UredjajVM Uredjaj { get; set; }
        public List<KomponenteVM> ZamijenjeniElementi { get; set; } = new List<KomponenteVM>();

    }
}
