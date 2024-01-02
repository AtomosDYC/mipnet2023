using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mvl02TablaSincronizacion
{

    public Guid userid { get; set; }

    public string? nombreTabla { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
