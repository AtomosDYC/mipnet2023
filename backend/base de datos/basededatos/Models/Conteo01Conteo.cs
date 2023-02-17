using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Conteo01Conteo
{
    public decimal Conteo01Llave { get; set; }

    public decimal? Trp01Llave { get; set; }

    public decimal? Conteo01Valor { get; set; }

    public DateTime? Conteo01FechaIngreso { get; set; }

    public DateTime? Conteo01HoraIngreso { get; set; }

    public int? Conteo01EstadoVisado { get; set; }

    public string? Conteo01X { get; set; }

    public string? Conteo01Y { get; set; }

    public string? Conteo01Observacion { get; set; }

    public int? Conteo01EstadoConteo { get; set; }

    public decimal? Conteo01TipoSistema { get; set; }

    public decimal? Temp02Llave { get; set; }

    public string? Mvl01Llave { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }
}
