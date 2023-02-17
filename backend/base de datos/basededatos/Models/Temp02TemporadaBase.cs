using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Temp02TemporadaBase
{
    public decimal Temp02Llave { get; set; }

    public string? Temp02Nombre { get; set; }

    public string? Temp02Descripcion { get; set; }

    public int? Temp02Predeterminada { get; set; }

    public int? Temp02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Conteo01Conteo> Conteo01Conteos { get; } = new List<Conteo01Conteo>();

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual ICollection<Mnt03PeriodosTrampa> Mnt03PeriodosTrampas { get; } = new List<Mnt03PeriodosTrampa>();

    public virtual ICollection<Obsc01ObservacionCampo> Obsc01ObservacionCampos { get; } = new List<Obsc01ObservacionCampo>();

    public virtual ICollection<Temp01Temporadum> Temp01Temporada { get; } = new List<Temp01Temporadum>();

    public virtual ICollection<Trp02Temporadum> Trp02Temporada { get; } = new List<Trp02Temporadum>();
}
