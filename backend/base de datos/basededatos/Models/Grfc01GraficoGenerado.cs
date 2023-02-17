using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Grfc01GraficoGenerado
{
    public decimal Grfc01Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public DateTime? Grfc01FechaGrafico { get; set; }

    public string? Grfc01CodigoGrafico { get; set; }

    public decimal? Grfc02Llave { get; set; }

    public int? Grfc01Estado { get; set; }
}
