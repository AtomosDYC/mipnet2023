using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mvl02TablaSincronizacion
{
    public Guid Secu02Llave { get; set; }

    public string? NombreTabla { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
