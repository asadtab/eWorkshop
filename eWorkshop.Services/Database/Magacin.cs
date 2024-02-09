using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eWorkshop.Services.Database;

public partial class Magacin
{
    [Key]
    public int MagacinId { get; set; }

    public int? KomponentaId { get; set; }

    public int? Kolicina { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public virtual Komponente? Komponenta { get; set; }
}
