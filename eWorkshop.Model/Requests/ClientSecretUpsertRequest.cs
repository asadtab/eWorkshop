using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class ClientSecretUpsertRequest
    {
        public string Description { get; set; }

        public string Value { get; set; } = null;

        public DateTime? Expiration { get; set; }

        public string Type { get; set; } = null;

        public DateTime Created { get; set; }
    }
}
