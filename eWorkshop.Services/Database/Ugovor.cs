using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Ugovor
{
    public int UgovorId { get; set; }

    public int RadniZadatakId { get; set; }

    public DateTime? Datum { get; set; }

    public int? Cijena { get; set; }

    public virtual RadniZadatak RadniZadatak { get; set; } = null!;
}
