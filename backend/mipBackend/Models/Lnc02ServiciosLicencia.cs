using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc02ServiciosLicencia
{
    public int Lnc01Llave { get; set; }

    public int Serv01Llave { get; set; }

    public int? Lnc02NumeroElemento { get; set; }

    public int? Lnc02EsIlimitado { get; set; }

    public int? Lnc02Activo { get; set; }

    public int? Lnc02PermiteComparar { get; set; }

    public virtual Lnc01Licencia Lnc01LlaveNavigation { get; set; } = null!;

    public virtual Serv01Servicio Serv01LlaveNavigation { get; set; } = null!;
}
