using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mnt01Monitor
{
    public int Mnt01Llave { get; set; }

    public int? Per01Llave { get; set; }

    public int? Mnt04Llave { get; set; }

    public string? Mnt01Cargo { get; set; }

    public DateTime? Mnt01Iniciolabores { get; set; }

    public int? Mnt01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Mnt03PeriodosTrampa> Mnt03PeriodosTrampas { get; } = new List<Mnt03PeriodosTrampa>();

    public virtual Mnt04TipoMonitor? Mnt04LlaveNavigation { get; set; }

    public virtual ICollection<Esp02TemporadaEspecie> Esp02Llaves { get; } = new List<Esp02TemporadaEspecie>();
}
