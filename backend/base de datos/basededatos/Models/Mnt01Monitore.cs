using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Mnt01Monitore
{
    public decimal Mnt01Llave { get; set; }

    public decimal? Per01Llave { get; set; }

    public decimal? Mnt04Llave { get; set; }

    public string? Mnt01Cargo { get; set; }

    public DateTime? Mnt01Iniciolabores { get; set; }

    public int? Mnt01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Mnt03PeriodosTrampa> Mnt03PeriodosTrampas { get; } = new List<Mnt03PeriodosTrampa>();

    public virtual Mnt04TipoMonitor? Mnt04LlaveNavigation { get; set; }

    public virtual ICollection<Esp02TemporadaEspecie> Esp02Llaves { get; } = new List<Esp02TemporadaEspecie>();
}
