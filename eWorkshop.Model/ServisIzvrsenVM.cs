using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ServisIzvrsenVM
    {
        //public int KomponentaId { get; set; }

        //public int ServisId { get; set; }

        public DateTime Datum { get; set; }

        public KomponenteVM Komponenta { get; set; } = new KomponenteVM();

        public ServisVM Servis { get; set; } = new ServisVM();

    }
}
