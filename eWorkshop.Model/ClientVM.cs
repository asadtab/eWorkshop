using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ClientVM
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public string ProtocolType { get; set; }
        public ICollection<string> AllowedGrantTypes { get; set; }
        public List<string> RedirectUris { get; set; }
    }
}
