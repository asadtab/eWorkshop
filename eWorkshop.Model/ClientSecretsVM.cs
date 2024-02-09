using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ClientSecretsVM
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Value { get; set; } 

        public DateTime Expiration { get; set; }

        public string Type { get; set; } 

        public DateTime Created { get; set; }
    }
}
