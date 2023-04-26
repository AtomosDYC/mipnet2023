using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Conteo01Conteo
{
    public int Conteo01Llave { get; set; }

    public int? Trp01Llave { get; set; }

    public int? Conteo01Valor { get; set; }

    public DateTime? Conteo01FechaIngreso { get; set; }

    public DateTime? Conteo01HoraIngreso { get; set; }

    public int? Conteo01EstadoVisado { get; set; }

    public string? Conteo01X { get; set; }

    public string? Conteo01Y { get; set; }

    public string? Conteo01Observacion { get; set; }

    public int? Conteo01EstadoConteo { get; set; }

    public int? Conteo01TipoSistema { get; set; }

    public int? Temp02Llave { get; set; }

    public string? Mvl01Llave { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Temp02TemporadaBase? Temp02LlaveNavigation { get; set; }
}
