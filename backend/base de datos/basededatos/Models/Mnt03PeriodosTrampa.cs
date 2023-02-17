using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Mnt03PeriodosTrampa
{
    public decimal Mnt01Llave { get; set; }

    public decimal Trp01Llave { get; set; }

    public decimal Temp02Llave { get; set; }

    public int? Mnt03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public Guid? ApproveBy { get; set; }

    public virtual Mnt01Monitore Mnt01LlaveNavigation { get; set; } = null!;

    public virtual Temp02TemporadaBase Temp02LlaveNavigation { get; set; } = null!;
}
