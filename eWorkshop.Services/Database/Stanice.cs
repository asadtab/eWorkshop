using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Stanice
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<StaniceUredjaj> StaniceUredjajs { get; } = new List<StaniceUredjaj>();
}
