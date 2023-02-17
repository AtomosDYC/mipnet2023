using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt16TipoBloqueoCliente
{
    public int Cnt16Llave { get; set; }

    public string? Cnt16Nombre { get; set; }

    public string? Cnt16Descripcion { get; set; }

    public bool? Cnt16Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
