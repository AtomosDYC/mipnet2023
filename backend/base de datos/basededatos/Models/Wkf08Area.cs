using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Wkf08Area
{
    public decimal Wfk08Llave { get; set; }

    public string? Wfk08Nombre { get; set; }

    public string? Wfk08Descripcion { get; set; }

    public bool? Wfk08Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }
}
