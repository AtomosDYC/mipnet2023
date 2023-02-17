using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt04ContactoCliente
{
    public int Cnt04Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Per01Llave { get; set; }

    public int? Cnt05Llave { get; set; }

    public int? Cnt04Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt01CuentaCliente Cnt01LlaveNavigation { get; set; } = null!;

    public virtual Cnt05TipoContacto Cnt05LlaveNavigation { get; set; } = null!;
}
