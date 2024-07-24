using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class RadniZadatakVM
    {
        public int RadniZadatakId { get; set; }

        public string Naziv { get; set; }

        public DateTime Datum { get; set; }

        public string StateMachine { get; set; }
    }
}
