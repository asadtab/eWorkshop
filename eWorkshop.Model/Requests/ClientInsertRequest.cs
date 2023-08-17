using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ClientInsertRequest
    {
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string ClientUri { get; set; }
        public string ProtocolType { get; set; }
        public ICollection<string> AllowedGrantTypes { get; set; }
        public ICollection<ClientScopeVM> ClientScopes { get; } = new List<ClientScopeVM>();
        public bool RequirePkce { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public ICollection<ClientSecretsVM> ClientSecrets { get; } = new List<ClientSecretsVM>();
    }
}
