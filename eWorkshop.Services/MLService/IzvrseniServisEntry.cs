using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.MLService
{
    public class IzvrseniServisEntry
    {
        [KeyType(count: 5)]
        public uint WithThisKomponentaID { get; set; }

        [KeyType(count: 5)]
        public uint KomponentaID { get; set; }

        public float Label { get; set; }
    }
}
