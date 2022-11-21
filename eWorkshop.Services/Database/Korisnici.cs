using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class Korisnici
{
    public int KorisniciId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string KorisnickoIme { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string LozinkaHash { get; set; } = null!;

    public string LozinkaSalt { get; set; } = null!;

    public string? Telefon { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; } = new List<KorisniciUloge>();

    public virtual ICollection<Servi> Servis { get; } = new List<Servi>();
}
