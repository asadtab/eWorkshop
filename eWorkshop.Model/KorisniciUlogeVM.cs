using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class KorisniciUlogeVM
    {
        public int KorisnikUlogaId { get; set; }

        public int KorisnikId { get; set; }

        public int UlogaId { get; set; }


        public virtual UlogeVM Uloga { get; set; } 
    }
}
