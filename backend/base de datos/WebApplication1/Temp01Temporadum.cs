using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Temp01Temporadum
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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Esp02TemporadaEspecie> Esp02TemporadaEspecies { get; set; } = new List<Esp02TemporadaEspecie>();

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }

    public virtual Temp03Segmentacion? Temp03LlaveNavigation { get; set; }
}
