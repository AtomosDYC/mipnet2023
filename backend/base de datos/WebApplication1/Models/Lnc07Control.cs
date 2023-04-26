using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lnc07Control
{
    public int Lnc01Llave { get; set; }

    public int Esp03Llave { get; set; }

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;
}
