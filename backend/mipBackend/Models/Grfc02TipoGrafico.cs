using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Grfc02TipoGrafico
{
    public int Grfc02Llave { get; set; }

    public string? Grfc02Nombre { get; set; }

    public string? Grfc02Descripcion { get; set; }

    public int? Grfc02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
