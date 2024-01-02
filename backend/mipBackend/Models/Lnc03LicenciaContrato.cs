using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc03LicenciaContrato
{
    public int Lnc01llave { get; set; }

    public int Ctt01llave { get; set; }

    public int? Lnc03FirmaSimpre { get; set; }

    public int? Lnc03activo { get; set; }

    public virtual Ctt01Contrato Ctt01llaveNavigation { get; set; } = null!;

    public virtual Lnc01Licencia Lnc01llaveNavigation { get; set; } = null!;
}
