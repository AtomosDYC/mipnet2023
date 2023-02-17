using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt04ContactoCliente
{
    public decimal Cnt04Llave { get; set; }

    public decimal Cnt01Llave { get; set; }

    public decimal Per01Llave { get; set; }

    public decimal Cnt05Llave { get; set; }

    public int? Cnt04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt01CuentaCliente Cnt01LlaveNavigation { get; set; } = null!;

    public virtual Cnt05TipoContacto Cnt05LlaveNavigation { get; set; } = null!;
}
