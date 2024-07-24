using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class StaniceUredjajVM
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public int UredjajId { get; set; }

        public string Koda { get; set; }
        public string UredjajNaziv { get; set; }
        public string UredjajTip { get; set; }
    }
}
