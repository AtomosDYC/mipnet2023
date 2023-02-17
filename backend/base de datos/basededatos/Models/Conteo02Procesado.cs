using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Conteo02Procesado
{
    public decimal Conteo02Llave { get; set; }

    public decimal? Cnt08Llave { get; set; }

    public decimal? Esp01Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public DateTime? Conteo02FechaProceso { get; set; }

    public decimal? Conteo02Promedio { get; set; }

    public decimal? Conteo02Cantidad { get; set; }

    public string? Conteo02Cotatenado { get; set; }

    public decimal? Conteo02Suma { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }
}
