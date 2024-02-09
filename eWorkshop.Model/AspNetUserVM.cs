using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class AspNetUserVM
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<AspNetUserClaimVM> AspNetUserClaims { get; } = new List<AspNetUserClaimVM>();
    }
}
