using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class UredjajUpsertRequest
    {
        public int TipId { get; set; }

        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public string GodinaIzvedbe { get; set; }

        public int LokacijaId { get; set; }

        public bool isDeleted { get; set; } = false;
    }
}
