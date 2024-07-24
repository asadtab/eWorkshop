using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class RadniZadatakUpsertRequest
    {
        public string Naziv { get; set; }

        public DateTime Datum { get; set; }

        //public string StateMachine { get; set; }
    }
}
