﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Service
{
    public class IdentityServerSettings
    {
        public string DiscoveryUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientPassword { get; set; }
        public bool UseHttps { get; set; }
    }
}
