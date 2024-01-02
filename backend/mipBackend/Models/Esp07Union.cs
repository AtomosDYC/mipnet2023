using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp07Union
{
    public int esp03llave { get; set; }

    public int esp03llaveUnion { get; set; }

    public virtual esp03especieBase esp03llaveNavigation { get; set; } = null!;
}
