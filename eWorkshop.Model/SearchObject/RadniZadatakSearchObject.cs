using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.SearchObject
{
    public class RadniZadatakSearchObject
    {
        public int RadniZadatakId { get; set; }

        public string Naziv { get; set; }

        public DateTime Datum { get; set; }

        public string StateMachine { get; set; }

        public string[] StateMachineArray { get; set; } = { };
    }
}
