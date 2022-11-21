using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class KorisniciVM
    {
        public int KorisniciId { get; set; }

        public string Ime { get; set; } 

        public string Prezime { get; set; } 

        public string KorisnickoIme { get; set; } 

        public string Email { get; set; } 

        public string Telefon { get; set; }

        public bool Status { get; set; }
    }
}
