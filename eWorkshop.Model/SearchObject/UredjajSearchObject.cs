using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.SearchObject
{
    public class UredjajSearchObject
    {
        public int UredjajId { get; set; }

        public int Tip { get; set; }

        public string Koda { get; set; }

        public string SerijskiBroj { get; set; }

        public string StateMachine { get; set; }

        public int Lokacija { get; set; }
    }
}
