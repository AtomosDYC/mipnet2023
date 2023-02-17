using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Men01Sistema
{
    public decimal Men01Llave { get; set; }

    public string? Men01Url { get; set; }

    public string? Men01Titulo { get; set; }

    public string? Men01Descripcion { get; set; }

    public string? Men01Tooltip { get; set; }

    public string? Men01Area { get; set; }

    public string? Men01Control { get; set; }

    public string? Men01Accion { get; set; }

    public decimal? Men01LlavePadre { get; set; }

    public string? Men01IconoUrl { get; set; }

    public bool Men01Principal { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }
}
