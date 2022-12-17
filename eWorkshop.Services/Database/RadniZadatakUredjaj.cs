using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class RadniZadatakUredjaj
{
    public int Id { get; set; }

    public int RadniZadatakId { get; set; }

    public int UredjajId { get; set; }

    public string? Napomena { get; set; }

    public int? KorisnikId { get; set; }

    public virtual Korisnici? Korisnik { get; set; }

    public virtual RadniZadatak RadniZadatak { get; set; } = null!;

    public virtual Uredjaj Uredjaj { get; set; } = null!;
}
