using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Trp02Temporada
{
    public int Trp02Llave { get; set; }

    public int Trp01Llave { get; set; }

    public int Temp02Llave { get; set; }

    public bool? Temp02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Temp02TemporadaBase Temp02LlaveNavigation { get; set; } = null!;

    public virtual Trp01Trampa Trp01LlaveNavigation { get; set; } = null!;
}
