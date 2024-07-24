using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ServisIzvrsenVM
    {
        //public int KomponentaId { get; set; }

        //public int ServisId { get; set; }

        public string Datum { get; set; }

        public KomponenteVM Komponenta { get; set; } = new KomponenteVM();

        public ServisVM Servis { get; set; } = new ServisVM();  


        public int UredjajId { get { return Servis.UredjajId; } set { } }
        public int ServisId { get { return Servis.ServisId; } set { } }
        public int KomponentaId { get { return Komponenta.KomponentaId; } set { } }
        public string komponentaNaziv { get { return Komponenta?.Naziv; } set { } }
        public string komponentaVrijednost { get { return Komponenta?.Vrijednost; } set { } }
        public string komponentaOpis { get { return Komponenta?.Opis; } set { } }
        public string komponentaTip { get { return Komponenta?.Tip; } set { } }
    }
}
