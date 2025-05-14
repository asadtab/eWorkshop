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
        public string RadnaJedinica { get; set; }

        public bool Status { get; set; }

        public List<string> Uloge { get; set; }

    }
}
