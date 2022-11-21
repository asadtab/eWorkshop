using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class RadniZadatak
{
    public int RadniZadatakId { get; set; }

    public string? Naziv { get; set; }

    public DateTime? Datum { get; set; }

    public string? StateMachine { get; set; }

    public virtual ICollection<Servi> Servis { get; } = new List<Servi>();

    public virtual ICollection<Ugovor> Ugovors { get; } = new List<Ugovor>();
}
