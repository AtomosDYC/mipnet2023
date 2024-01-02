using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc06Cobertura
{
    public int Lnc01llave { get; set; }

    public int sist03llave { get; set; }

    public virtual Lnc01Licencia Lnc01llaveNavigation { get; set; } = null!;
}
