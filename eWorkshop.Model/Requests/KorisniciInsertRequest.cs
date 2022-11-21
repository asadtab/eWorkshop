using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class KorisniciInsertRequest
    {

        public string Ime { get; set; } 

        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Email { get; set; }

        public string LozinkaHash { get; set; }

        public string LozinkaSalt { get; set; }

        public string Telefon { get; set; }

        public bool Status { get; set; }
    }
}
