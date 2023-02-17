using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt14ClienteLicencia
{
    public int Cnt14Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Lnc01Llave { get; set; }

    public DateTime? Cnt14InicioFecha { get; set; }

    public DateTime? Cnt14TerminoFecha { get; set; }

    public int? Cnt14CantUsuarios { get; set; }

    public bool? Cnt14Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual Cnt01CuentaCliente Cnt01LlaveNavigation { get; set; } = null!;

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
