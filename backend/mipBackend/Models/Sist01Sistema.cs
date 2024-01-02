using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class sist01sistema
{
    public int sist01llave { get; set; }

    public string? sist01nombre { get; set; }

    public string? sist01descripcion { get; set; }

    public bool? sist01EsPublica { get; set; }

    public bool? sist01EsServicios { get; set; }

    public bool? sist01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
