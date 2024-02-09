using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Lokacija
{
    public int LokacijaId { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public virtual ICollection<Uredjaj> Uredjajs { get; } = new List<Uredjaj>();
}
