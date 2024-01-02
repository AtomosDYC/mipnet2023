using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt04ContactoCliente
{
    public int cnt04llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? per01llave { get; set; }

    public int? cnt05llave { get; set; }

    public int? cnt04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt01CuentaCliente cnt01llaveNavigation { get; set; } = null!;

    public virtual cnt05TipoContacto cnt05llaveNavigation { get; set; } = null!;
}
