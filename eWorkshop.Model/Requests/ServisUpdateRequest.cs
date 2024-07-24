using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ServisUpdateRequest
    {
        public string Napomena { get; set; }

        public int RadniZadatakId { get; set; }

        public DateTime? Datum { get; set; }
    }
}
