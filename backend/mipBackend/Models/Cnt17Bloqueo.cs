﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt17Bloqueo
{
    public int Cnt17Llave { get; set; }

    public int? Blk01Llave { get; set; }

    public int? Cnt16Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Cnt14Llave { get; set; }

    public int? Per01Llave { get; set; }

    public DateTime? Cnt17InicioBloqueo { get; set; }

    public DateTime? Cnt17TerminoBloqueo { get; set; }

    public bool? Cnt17Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Blk01Bloqueo? Blk01LlaveNavigation { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }

    public virtual Cnt14ClienteLicencia? Cnt14LlaveNavigation { get; set; }

    public virtual Cnt16TipoBloqueoCliente? Cnt16LlaveNavigation { get; set; }
}
