using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt16TipoBloqueoCliente
{
    public int cnt16llave { get; set; }

    public string? cnt16nombre { get; set; }

    public string? cnt16descripcion { get; set; }

    public bool? cnt16activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual ICollection<cnt17Bloqueo> cnt17Bloqueos { get; } = new List<cnt17Bloqueo>();
}
