using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class UredjajVM
    {
        public int UredjajId { get; set; }

        public int TipId{ get; set; }

        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public DateTime DatumIzvedbe { get; set; }

        public string StateMachine { get; set; }

        public int LokacijaId { get; set; }
    }
}
