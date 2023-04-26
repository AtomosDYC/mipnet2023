using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Trp02Temporadum
{
    public int Trp02Llave { get; set; }

    public int Trp01Llave { get; set; }

    public int Temp02Llave { get; set; }

    public bool? Temp02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Temp02TemporadaBase Temp02LlaveNavigation { get; set; } = null!;

    public virtual Trp01Trampa Trp01LlaveNavigation { get; set; } = null!;
}
