using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp01Temporada
{
    public int Temp01Llave { get; set; }

    public string Temp01Nombre { get; set; } = null!;

    public string? Temp01Descripcion { get; set; }

    public int? Temp02Llave { get; set; }

    public int? Temp03Llave { get; set; }

    public DateTime? Temp01MinFecha { get; set; }

    public DateTime? Temp01MaxFecha { get; set; }

    public int? Temp01MinMes { get; set; }

    public int? Temp01MaxMes { get; set; }

    public int? Temp01Periodo { get; set; }

    public int? Temp01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp02TemporadaEspecie> Esp02TemporadaEspecies { get; } = new List<Esp02TemporadaEspecie>();

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }

    public virtual Temp03Segmentacion? Temp03LlaveNavigation { get; set; }
}
