using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class KorisniciUpdateRequest
    {

        public string Ime { get; set; }

        public string Prezime { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }


        public string Email { get; set; }
        public string RadnaJedinica { get; set; }

        public bool Status { get; set; }

        public List<string> KorisniciUloge { get; set; }

    }
}
