﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp03Segmentacion
{
    public int temp03llave { get; set; }

    public string? temp03nombre { get; set; }

    public string? temp03descripcion { get; set; }

    public int? temp03numeromeses { get; set; }

    public int? temp03numerosegmentostotal { get; set; }

    public int? temp03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Temp01Temporada> Temp01Temporada { get; } = new List<Temp01Temporada>();
}
