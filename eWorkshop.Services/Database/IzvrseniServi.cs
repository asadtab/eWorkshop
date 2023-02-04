using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class IzvrseniServi
{
    public int IzvrseniServisId { get; set; }

    public int? KomponentaId { get; set; }

    public int? ServisId { get; set; }

    public string? KomponentaNaziv { get; set; }
    public string? KomponentaVrijednost { get; set; }
    public string? KomponentaTip { get; set; }

    public DateTime? Datum { get; set; }

    public virtual Komponente? Komponenta { get; set; }

    public virtual Servi? Servis { get; set; }
}
