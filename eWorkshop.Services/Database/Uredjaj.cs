using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eWorkshop.Services.Database;

public partial class Uredjaj
{
    [Key]
    public int UredjajId { get; set; }

    public int TipId { get; set; }

    public string Koda { get; set; } = null!;

    public string SerijskiBroj { get; set; } = null!;

    public string? GodinaIzvedbe { get; set; }

    public string? Status { get; set; }

    public int? LokacijaId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Lokacija? Lokacija { get; set; }

    public virtual ICollection<RadniZadatakUredjaj> RadniZadatakUredjajs { get; } = new List<RadniZadatakUredjaj>();

    public virtual ICollection<Servi> Servis { get; } = new List<Servi>();


    public virtual TipUredjaja Tip { get; set; } = null!;
}
