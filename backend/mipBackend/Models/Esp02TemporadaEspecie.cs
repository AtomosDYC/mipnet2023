using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class esp02Temporadaespecie
{
    public int esp02llave { get; set; }

    public int? esp01llave { get; set; }

    public int? Temp01llave { get; set; }

    public DateTime? esp02InicioTemporada { get; set; }

    public DateTime? esp02TerminoTemporada { get; set; }

    public int? esp02Sag { get; set; }

    public int? esp02Mexico { get; set; }

    public int? esp02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual esp01especie? esp01llaveNavigation { get; set; }

    public virtual Temp01Temporada? Temp01llaveNavigation { get; set; }

    public virtual ICollection<Mnt01Monitor> Mnt01llaves { get; } = new List<Mnt01Monitor>();

    public virtual ICollection<Mnt02EspeciesAsignada> Mnt02EspeciesAsignadas { get; } = new List<Mnt02EspeciesAsignada>();
}
