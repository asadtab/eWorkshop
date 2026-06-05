using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Database
{
    public class Prijem
    {
        [Key]
        public int Id { get; set; }
        public string OpisStanja { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey(nameof(Uredjaj))]
        public int UredjajId { get; set; }
        public Uredjaj Uredjaj { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }
    }
}
