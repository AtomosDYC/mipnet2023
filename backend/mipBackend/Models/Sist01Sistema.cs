using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sist01Sistema
{
    public int Sist01Llave { get; set; }

    public string? Sist01Nombre { get; set; }

    public string? Sist01Descripcion { get; set; }

    public bool? Sist01EsPublica { get; set; }

    public bool? Sist01EsServicios { get; set; }

    public bool? Sist01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
