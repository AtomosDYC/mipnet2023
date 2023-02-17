using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt16TipoBloqueoCliente
{
    public decimal Cnt16Llave { get; set; }

    public string? Cnt16Nombre { get; set; }

    public string? Cnt16Descripcion { get; set; }

    public bool? Cnt16Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
