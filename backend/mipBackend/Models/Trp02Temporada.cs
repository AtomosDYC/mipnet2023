using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Trp02Temporada
{
    public int Trp02llave { get; set; }

    public int Trp01llave { get; set; }

    public int Temp02llave { get; set; }

    public bool? Temp02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Temp02TemporadaBase Temp02llaveNavigation { get; set; } = null!;

    public virtual Trp01Trampa Trp01llaveNavigation { get; set; } = null!;
}
