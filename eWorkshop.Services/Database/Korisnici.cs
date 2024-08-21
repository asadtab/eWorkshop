using Microsoft.AspNetCore.Identity;

namespace eWorkshop.Services.Database;

public partial class Korisnici : IdentityUser<int>
{
    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public bool? Status { get; set; }

    public string? RadnaJedinica { get; set; }


    public virtual ICollection<RadniZadatakUredjaj> RadniZadatakUredjajs { get; } = new List<RadniZadatakUredjaj>();
    public virtual ICollection<Servi> Servis { get; } = new List<Servi>();
    public virtual ICollection<KorisniciUloge> KorisniciUloge { get; } = new List<KorisniciUloge>();

}
