﻿using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Mvl02TablaSincronizacion
{
    public Guid Secu02Llave { get; set; }

    public string? NombreTabla { get; set; }

    public DateTime? FechaUltimaActualizacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }
}
