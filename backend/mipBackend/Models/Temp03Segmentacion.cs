using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Temp03Segmentacion
{
    public int Temp03Llave { get; set; }

    public string? Temp03Nombre { get; set; }

    public string? Temp03Descripcion { get; set; }

    public int? Temp03NumeroMeses { get; set; }

    public int? Temp03NumeroSegmentosTotal { get; set; }

    public int? Temp03Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Temp01Temporada> Temp01Temporada { get; } = new List<Temp01Temporada>();
}
