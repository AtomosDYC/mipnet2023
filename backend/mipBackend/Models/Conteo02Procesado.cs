using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo02Procesado
{
    public int Conteo02Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Esp01Llave { get; set; }

    public int? Temp02Llave { get; set; }

    public DateTime? Conteo02FechaProceso { get; set; }

    public int? Conteo02Promedio { get; set; }

    public int? Conteo02Cantidad { get; set; }

    public string? Conteo02Cotatenado { get; set; }

    public int? Conteo02Suma { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlaveNavigation { get; set; }
}
