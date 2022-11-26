using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class KomponenteUpsertRequest
    {
        public string Naziv { get; set; }

        public string Vrijednost { get; set; }

        public string Opis { get; set; }

        public string Tip { get; set; }
    }
}
