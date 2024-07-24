﻿using System;
using System.Collections.Generic;

namespace eWorkshop.Services.Database;

public partial class ApiResourceScope
{
    public int Id { get; set; }

    public string Scope { get; set; } = null!;

    public int ApiResourceId { get; set; }

    public virtual ApiResource ApiResource { get; set; } = null!;
}
