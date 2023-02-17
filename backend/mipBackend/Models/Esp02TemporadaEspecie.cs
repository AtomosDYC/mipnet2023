using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp02TemporadaEspecie
{
    public int Esp02Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp01Llave { get; set; }

    public DateTime? Esp02InicioTemporada { get; set; }

    public DateTime? Esp02TerminoTemporada { get; set; }

    public int? Esp02Sag { get; set; }

    public int? Esp02Mexico { get; set; }

    public int? Esp02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Esp01Especie? Esp01LlaveNavigation { get; set; }

    public virtual Temp01Temporada? Temp01LlaveNavigation { get; set; }

    public virtual ICollection<Mnt01Monitor> Mnt01Llaves { get; } = new List<Mnt01Monitor>();
}
