using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc02ServiciosLicencia
{
    public int Lnc01llave { get; set; }

    public int Serv01llave { get; set; }

    public int? Lnc02NumeroElemento { get; set; }

    public int? Lnc02EsIlimitado { get; set; }

    public int? Lnc02activo { get; set; }

    public int? Lnc02permiteComparar { get; set; }

    public virtual Lnc01Licencia Lnc01llaveNavigation { get; set; } = null!;

    public virtual Serv01Servicio Serv01llaveNavigation { get; set; } = null!;
}
