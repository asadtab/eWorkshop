using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eWorkshop.Model
{
    public class KorisniciVM
    {
        public int Id { get; set; }

        public string Ime { get; set; }     

        public string Prezime { get; set; } 

        public string UserName { get; set; } 

        public string Email { get; set; } 


        public bool Status { get; set; }

        public string RadnaJedinica { get; set; }

        public List<string> Uloge { get; set; } = new List<string>();

    }
}
