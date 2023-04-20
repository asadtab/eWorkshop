using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.SearchObject
{
    public class RadniZadatakUredjajSearchObject
    {
        public int RadniZadatakId { get; set; }

        public int UredjajId { get; set; }

        public int KorisnikId { get; set; }

        public string UredjajState { get; set; }
        public string RadniZadatakState { get; set; }

        public string[] ZadatakState { get; set; } = { };
    }
}
