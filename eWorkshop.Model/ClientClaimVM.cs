using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ClientClaimVM
    {
        public string Type { get; set; } 

        public string Value { get; set; }

        public int ClientId { get; set; }

        public virtual ClientVM Client { get; set; }
    }
}
