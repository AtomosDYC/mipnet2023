using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Lnc06Cobertura
{
    public decimal Lnc01Llave { get; set; }

    public decimal Sist03Llave { get; set; }

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;
}
