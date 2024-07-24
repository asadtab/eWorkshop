using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public string ProtocolType { get; set; }
        public ICollection<string> GrantType { get; set; }
        public ICollection<ClientGrantTypeVM> ClientGrantTypes { get; set; }
        public List<string> RedirectUris { get; set; }
    }
}
