using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class AspNetUserInsertRequest
    {

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Ime { get; set; } = null;

        public string Prezime { get; set; } = null;

        public List<string> Uloge { get; set; }
    }
}
