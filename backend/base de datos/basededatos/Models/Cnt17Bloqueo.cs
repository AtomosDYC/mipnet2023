using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt17Bloqueo
{
    public decimal Cnt17Llave { get; set; }

    public decimal? Blk01Llave { get; set; }

    public decimal? Cnt16Llave { get; set; }

    public decimal? Cnt01Llave { get; set; }

    public decimal? Cnt08Llave { get; set; }

    public decimal? Cnt14Llave { get; set; }

    public decimal? Per01Llave { get; set; }

    public DateTime? Cnt17InicioBloqueo { get; set; }

    public DateTime? Cnt17TerminoBloqueo { get; set; }

    public bool? Cnt17Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Blk01Bloqueo? Blk01LlaveNavigation { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual Cnt14ClienteLicencium? Cnt14LlaveNavigation { get; set; }

    public virtual Cnt16TipoBloqueoCliente? Cnt16LlaveNavigation { get; set; }
}
