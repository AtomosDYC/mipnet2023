using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt01Monitor
{
    public int mnt01llave { get; set; }

    public int? per01llave { get; set; }

    public int? mnt04llave { get; set; }

    public string? mnt01Cargo { get; set; }

    public DateTime? mnt01Iniciolabores { get; set; }

    public int? mnt01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Mnt03periodosTrampa> Mnt03periodosTrampas { get; } = new List<Mnt03periodosTrampa>();

    public virtual ICollection<Mnt02EspeciesAsignada> Mnt02EspeciesAsignadas { get; } = new List<Mnt02EspeciesAsignada>();

    public virtual Mnt04TipoMonitor? Mnt04llaveNavigation { get; set; }

    public virtual ICollection<esp02Temporadaespecie> esp02llaves { get; } = new List<esp02Temporadaespecie>();
}
