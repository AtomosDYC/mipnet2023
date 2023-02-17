using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Grfc02TipoGrafico
{
    public decimal Grfc02Llave { get; set; }

    public string? Grfc02Nombre { get; set; }

    public string? Grfc02Descripcion { get; set; }

    public int? Grfc02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
