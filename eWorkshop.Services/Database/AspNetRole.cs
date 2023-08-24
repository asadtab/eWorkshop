using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class AspNetRole: IdentityRole
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetUser> Users { get; } = new List<AspNetUser>();
}
