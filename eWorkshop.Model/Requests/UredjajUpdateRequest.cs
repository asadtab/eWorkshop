using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class UredjajUpdateRequest
    {
        public int TipId { get; set; }

        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public string DatumIzvedbe { get; set; }

        public int LokacijaId { get; set; }

        public bool isDeleted { get; set; } = false;
    }
}
