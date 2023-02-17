using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt14ClienteLicencium
{
    public decimal Cnt14Llave { get; set; }

    public decimal Cnt01Llave { get; set; }

    public decimal Lnc01Llave { get; set; }

    public DateTime? Cnt14InicioFecha { get; set; }

    public DateTime? Cnt14TerminoFecha { get; set; }

    public int? Cnt14CantUsuarios { get; set; }

    public bool? Cnt14Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Cnt01CuentaCliente Cnt01LlaveNavigation { get; set; } = null!;

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
