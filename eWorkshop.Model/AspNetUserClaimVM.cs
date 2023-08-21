using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class AspNetUserClaimVM
    {
        public string UserId { get; set; } 

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual AspNetUserVM User { get; set; }
    }
}
