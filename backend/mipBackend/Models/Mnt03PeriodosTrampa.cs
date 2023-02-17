using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt03PeriodosTrampa
{
    public int Mnt01Llave { get; set; }

    public int Trp01Llave { get; set; }

    public int Temp02Llave { get; set; }

    public int? Mnt03Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public Guid? approveby { get; set; }

    public virtual Mnt01Monitor Mnt01LlaveNavigation { get; set; } = null!;

    public virtual Temp02TemporadaBase Temp02LlaveNavigation { get; set; } = null!;
}
