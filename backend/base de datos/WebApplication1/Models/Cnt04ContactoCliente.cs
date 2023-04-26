using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cnt04ContactoCliente
{
    public int Cnt04Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Per01Llave { get; set; }

    public int? Cnt05Llave { get; set; }

    public int? Cnt04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual Cnt05TipoContacto? Cnt05LlaveNavigation { get; set; }
}
