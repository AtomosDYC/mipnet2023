using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Lnc03LicenciaContrato
{
    public decimal Lnc01Llave { get; set; }

    public decimal Ctt01Llave { get; set; }

    public int? Lnc03FirmaSimpre { get; set; }

    public int? Lnc03Activo { get; set; }

    public virtual Ctt01Contrato Ctt01LlaveNavigation { get; set; } = null!;

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;
}
