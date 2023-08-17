using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class StaniceUredjaj
{
    public int Id { get; set; }

    public int StanicaId { get; set; }

    public int UredjajId { get; set; }

    public virtual Stanice Stanica { get; set; } = null!;

    public virtual Uredjaj Uredjaj { get; set; } = null!;
}
