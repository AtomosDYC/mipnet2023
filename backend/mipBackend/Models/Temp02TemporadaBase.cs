using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp02TemporadaBase
{
    public int Temp02Llave { get; set; }

    public string? Temp02Nombre { get; set; }

    public string? Temp02Descripcion { get; set; }

    public int? Temp02Predeterminada { get; set; }

    public int? Temp02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Conteo01Conteo> Conteo01Conteos { get; } = new List<Conteo01Conteo>();

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Mnt03PeriodosTrampa> Mnt03PeriodosTrampas { get; } = new List<Mnt03PeriodosTrampa>();

    public virtual ICollection<Obsc01ObservacionCampo> Obsc01ObservacionCampos { get; } = new List<Obsc01ObservacionCampo>();

    public virtual ICollection<Temp01Temporada> Temp01Temporada { get; } = new List<Temp01Temporada>();

    public virtual ICollection<Trp02Temporada> Trp02Temporada { get; } = new List<Trp02Temporada>();
}
