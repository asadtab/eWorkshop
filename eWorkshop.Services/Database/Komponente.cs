using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Komponente
{
    public int KomponentaId { get; set; }

    public string? Naziv { get; set; }

    public string? Vrijednost { get; set; }

    public string? Opis { get; set; }

    public string? Tip { get; set; }

    public virtual ICollection<IzvrseniServi> IzvrseniServis { get; } = new List<IzvrseniServi>();

    public virtual ICollection<Magacin> Magacins { get; } = new List<Magacin>();
}
