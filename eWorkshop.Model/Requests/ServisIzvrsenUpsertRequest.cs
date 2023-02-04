using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ServisIzvrsenUpsertRequest
    {
        public int KomponentaId { get; set; }

        public int ServisId { get; set; }
        public string KomponentaNaziv { get; set; }
        public string KomponentaVrijednost { get; set; }
        public string KomponentaTip { get; set; }
    }
}
