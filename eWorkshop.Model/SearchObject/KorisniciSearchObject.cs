using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.SearchObject
{
    public class KorisniciSearchObject
    {
        public string KorisnickoIme { get; set; }
        public string ImePrezime { get; set; }
        public bool IncludeUloge { get; set; }
    }
}
