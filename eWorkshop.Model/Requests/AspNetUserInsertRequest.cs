using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model.Requests
{
    public class AspNetUserInsertRequest
    {
        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public virtual ICollection<AspNetRoleUpsertRequest> Roles { get; set; } = new List<AspNetRoleUpsertRequest>();
    }
}
