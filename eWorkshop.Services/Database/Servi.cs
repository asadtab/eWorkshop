using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Servi
{
    public int ServisId { get; set; }

    public string? Napomena { get; set; }

    public int KorisnikId { get; set; }

    public int UredjajId { get; set; }

    public int RadniZadatakId { get; set; }

    public DateTime? Datum { get; set; }

    public virtual ICollection<IzvrseniServi> IzvrseniServis { get; } = new List<IzvrseniServi>();

    public virtual Korisnici Korisnik { get; set; } = null!;

    public virtual RadniZadatak RadniZadatak { get; set; } = null!;

    public virtual Uredjaj Uredjaj { get; set; } = null!;
}
