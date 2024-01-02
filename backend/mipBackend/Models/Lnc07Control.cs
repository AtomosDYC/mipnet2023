using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc07Control
{
    public int Lnc01llave { get; set; }

    public int esp03llave { get; set; }

    public virtual Lnc01Licencia Lnc01llaveNavigation { get; set; } = null!;
}
