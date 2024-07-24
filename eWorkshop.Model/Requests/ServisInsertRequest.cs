using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ServisInsertRequest
    {
        public string Napomena { get; set; }

        public int KorisnikId { get; set; }

        public int UredjajId { get; set; }

        public int RadniZadatakId { get; set; }

        public DateTime? Datum { get; set; }

        public List<int> KomponenteIdList { get; set; } = new List<int>();
    }
}
