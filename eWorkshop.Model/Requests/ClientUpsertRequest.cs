using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ClientUpsertRequest
    {
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string ClientUri { get; set; }
        public string ProtocolType { get; set; }
        public bool RequireClientSecret { get; set; }
        public bool Enabled { get; set; }
        public bool RequirePkce { get; set; }
        public bool AllowOfflineAccess { get; set; }
    }
}
