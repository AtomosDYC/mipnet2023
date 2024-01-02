using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo02Procesado
{
    public int Conteo02llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? esp01llave { get; set; }

    public int? Temp02llave { get; set; }

    public DateTime? Conteo02FechaProceso { get; set; }

    public int? Conteo02Promedio { get; set; }

    public int? Conteo02Cantidad { get; set; }

    public string? Conteo02Cotatenado { get; set; }

    public int? Conteo02Suma { get; set; }

    public virtual cnt08Segmentacion? cnt08llaveNavigation { get; set; }
}
