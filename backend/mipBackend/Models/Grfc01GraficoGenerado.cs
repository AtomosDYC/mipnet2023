using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Grfc01GraficoGenerado
{
    public int Grfc01llave { get; set; }

    public Guid? userid { get; set; }

    public DateTime? Grfc01FechaGrafico { get; set; }

    public string? Grfc01CodigoGrafico { get; set; }

    public int? Grfc02llave { get; set; }

    public int? Grfc01Estado { get; set; }
}
