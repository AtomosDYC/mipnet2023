using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt14ClienteLicencia
{
    public int cnt14llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? Lnc01llave { get; set; }

    public DateTime? cnt14InicioFecha { get; set; }

    public DateTime? cnt14TerminoFecha { get; set; }

    public int? cnt14CantUsuarios { get; set; }

    public bool? cnt14activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual cnt01CuentaCliente cnt01llaveNavigation { get; set; } = null!;

    public virtual ICollection<cnt17Bloqueo> cnt17Bloqueos { get; } = new List<cnt17Bloqueo>();
}
