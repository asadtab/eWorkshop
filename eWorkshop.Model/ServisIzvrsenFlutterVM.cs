using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ServisIzvrsenFlutterVM
    {
        public int ServisId { get; set; }

        public int UredjajId { get; set; }

        public string Naziv { get; set; }

        public string Vrijednost { get; set; }

        public string Tip { get; set; }

        public string Datum { get; set; }

        public string Servisirao { get; set; }

        public int KomponentaId { get; set; }
    }
}
