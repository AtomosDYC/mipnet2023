using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf08Area
{
    public int wfk08llave { get; set; }

    public string? wfk08nombre { get; set; }

    public string? wfk08descripcion { get; set; }

    public bool? wfk08activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }
}
