using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Cnt05TipoContacto
{
    public int Cnt05Llave { get; set; }

    public string? Cnt05Nombre { get; set; }

    public string? Cnt05Descripcion { get; set; }

    public int? Cnt05Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt04ContactoCliente> Cnt04ContactoClientes { get; set; } = new List<Cnt04ContactoCliente>();
}
