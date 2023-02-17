using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Pgo03TipoPagoLicencium
{
    public decimal Pgo03Llave { get; set; }

    public string? Pgo03Nombre { get; set; }

    public string? Pgo03Descripcion { get; set; }

    public int? Pgo03Activo { get; set; }

    public virtual ICollection<Pgo01CompraLicencium> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencium>();
}
