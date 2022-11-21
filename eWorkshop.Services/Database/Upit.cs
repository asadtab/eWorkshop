using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Upit
{
    public int UpitId { get; set; }

    public string? Naslov { get; set; }

    public string? Opis { get; set; }

    public DateTime? Datum { get; set; }

    public int? KlijentId { get; set; }

    public virtual Klijenti? Klijent { get; set; }
}
