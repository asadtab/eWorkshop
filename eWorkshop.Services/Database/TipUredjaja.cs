using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class TipUredjaja
{
    public int TipUredjajaId { get; set; }

    public string Naziv { get; set; } = null!;

    public string Opis { get; set; } = null!;

    public virtual ICollection<Uredjaj> Uredjajs { get; } = new List<Uredjaj>();
}
