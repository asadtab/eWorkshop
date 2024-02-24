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
        public bool RequireClientSecret { get; set; }
        public bool Enabled { get; set; }   
        public ICollection<ClientGrantTypeUpsertRequest> ClientGrantTypes { get; set; } = new List<ClientGrantTypeUpsertRequest>();
        public ICollection<ClientScopeUpsertRequest> ClientScopes { get; set; } = new List<ClientScopeUpsertRequest>();
        public bool RequirePkce { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public ICollection<ClientSecretUpsertRequest> ClientSecrets { get; set; } = new List<ClientSecretUpsertRequest>();
    }
}
