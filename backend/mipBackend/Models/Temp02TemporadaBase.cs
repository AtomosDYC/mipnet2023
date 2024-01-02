using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp02TemporadaBase
{
    public int temp02llave { get; set; }

    public string? temp02nombre { get; set; }

    public string? temp02descripcion { get; set; }

    public int? temp02predeterminada { get; set; }

    public int? temp02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Conteo01Conteo> Conteo01Conteos { get; } = new List<Conteo01Conteo>();

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Mnt03periodosTrampa> Mnt03periodosTrampas { get; } = new List<Mnt03periodosTrampa>();

    public virtual ICollection<Obsc01ObservacionCampo> Obsc01ObservacionCampos { get; } = new List<Obsc01ObservacionCampo>();

    public virtual ICollection<Temp01Temporada> Temp01Temporada { get; } = new List<Temp01Temporada>();

    public virtual ICollection<Trp02Temporada> Trp02Temporada { get; } = new List<Trp02Temporada>();
}
