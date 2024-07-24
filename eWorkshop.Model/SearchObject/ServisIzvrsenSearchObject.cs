using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.SearchObject
{
    public class ServisIzvrsenSearchObject
    {
        public int ServisId { get; set; }

        public int UredjajId { get; set; }

        public int TipUredjajaId { get; set; }

        public string TipUredjajaNaziv { get; set; }

        public int KorisnikId { get; set; }
    }
}
