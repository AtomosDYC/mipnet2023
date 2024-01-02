using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt03periodosTrampa
{
    public int mnt01llave { get; set; }

    public int trp01llave { get; set; }

    public int temp02llave { get; set; }

    public int? mnt03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public Guid? approveby { get; set; }

    public virtual Mnt01Monitor Mnt01llaveNavigation { get; set; } = null!;

    public virtual Temp02TemporadaBase Temp02llaveNavigation { get; set; } = null!;

}
