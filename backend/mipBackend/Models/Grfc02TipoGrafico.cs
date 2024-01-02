using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Grfc02TipoGrafico
{
    public int Grfc02llave { get; set; }

    public string? Grfc02nombre { get; set; }

    public string? Grfc02descripcion { get; set; }

    public int? Grfc02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
