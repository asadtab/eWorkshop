using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class TipUredjajaVM
    {
        public int TipUredjajaId { get; set; }
        public string Naziv { get; set; } 
        public string Opis { get; set; }

        public string OpisNaziv {
            get
            {
                return this.Naziv + " - " + this.Opis;
            } set
            {
                
            }
        } 
    }
}
