using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lnc03LicenciaContrato
{
    public int Lnc01Llave { get; set; }

    public int Ctt01Llave { get; set; }

    public int? Lnc03FirmaSimpre { get; set; }

    public int? Lnc03Activo { get; set; }

    public virtual Ctt01Contrato Ctt01LlaveNavigation { get; set; } = null!;

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;
}
