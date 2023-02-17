using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Men01Sistema
{
    public int Men01Llave { get; set; }

    public string? Men01Url { get; set; }

    public string? Men01Titulo { get; set; }

    public string? Men01Descripcion { get; set; }

    public string? Men01Tooltip { get; set; }

    public string? Men01Area { get; set; }

    public string? Men01Control { get; set; }

    public string? Men01Accion { get; set; }

    public int? Men01LlavePadre { get; set; }

    public string? Men01IconoUrl { get; set; }

    public bool Men01Principal { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
