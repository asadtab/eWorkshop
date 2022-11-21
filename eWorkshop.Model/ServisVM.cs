using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ServisVM
    {
        public int ServisId { get; set; }

        public string Napomena { get; set; }

        public int KorisnikId { get; set; }

        public int UredjajId { get; set; }

        public int RadniZadatakId { get; set; }

        public DateTime? Datum { get; set; }
    }
}
