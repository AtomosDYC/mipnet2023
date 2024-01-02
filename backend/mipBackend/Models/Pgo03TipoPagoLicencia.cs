using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo03TipoPagoLicencia
{
    public int Pgo03llave { get; set; }

    public string? Pgo03nombre { get; set; }

    public string? Pgo03descripcion { get; set; }

    public int? Pgo03activo { get; set; }

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
