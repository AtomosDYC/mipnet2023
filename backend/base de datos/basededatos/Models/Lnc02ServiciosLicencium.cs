using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Lnc02ServiciosLicencium
{
    public decimal Lnc01Llave { get; set; }

    public decimal Serv01Llave { get; set; }

    public decimal? Lnc02NumeroElemento { get; set; }

    public int? Lnc02EsIlimitado { get; set; }

    public int? Lnc02Activo { get; set; }

    public int? Lnc02PermiteComparar { get; set; }

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;

    public virtual Serv01Servicio Serv01LlaveNavigation { get; set; } = null!;
}
