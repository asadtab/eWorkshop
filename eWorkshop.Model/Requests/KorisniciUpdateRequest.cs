using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class KorisniciUpdateRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

    }
}
