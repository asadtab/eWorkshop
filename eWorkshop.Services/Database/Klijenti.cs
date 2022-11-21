using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Klijenti
{
    public int KlijentId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? KorisnickoIme { get; set; }

    public string? Email { get; set; }

    public string? LozinkaHash { get; set; }

    public string? LozinkaSalt { get; set; }

    public virtual ICollection<Upit> Upits { get; } = new List<Upit>();
}
