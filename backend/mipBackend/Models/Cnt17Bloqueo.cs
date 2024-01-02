using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt17Bloqueo
{
    public int cnt17llave { get; set; }

    public int? Blk01llave { get; set; }

    public int? cnt16llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? cnt14llave { get; set; }

    public int? per01llave { get; set; }

    public DateTime? cnt17InicioBloqueo { get; set; }

    public DateTime? cnt17TerminoBloqueo { get; set; }

    public bool? cnt17activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Blk01Bloqueo? Blk01llaveNavigation { get; set; }

    public virtual cnt01CuentaCliente? cnt01llaveNavigation { get; set; }

    public virtual cnt08Segmentacion? cnt08llaveNavigation { get; set; }

    public virtual cnt14ClienteLicencia? cnt14llaveNavigation { get; set; }

    public virtual cnt16TipoBloqueoCliente? cnt16llaveNavigation { get; set; }
}
