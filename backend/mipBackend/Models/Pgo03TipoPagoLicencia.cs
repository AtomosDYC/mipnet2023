using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo03TipoPagoLicencia
{
    public int Pgo03Llave { get; set; }

    public string? Pgo03Nombre { get; set; }

    public string? Pgo03Descripcion { get; set; }

    public int? Pgo03Activo { get; set; }

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
