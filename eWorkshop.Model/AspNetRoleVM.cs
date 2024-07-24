using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Model
{
    public class AspNetRoleVM
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string NormalizedName { get; set; }


        //public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; } = new List<AspNetRoleClaim>();
    }
}
