using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class RadniZadatakUredjajUpsertRequest
    {
        public int RadniZadatakId { get; set; }

        public int UredjajId { get; set; }

        public string Napomena { get; set; }

        public string KorisnikId { get; set; }
    }
}
