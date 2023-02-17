using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt05TipoContacto
{
    public int Cnt05Llave { get; set; }

    public string? Cnt05Nombre { get; set; }

    public string? Cnt05Descripcion { get; set; }

    public int? Cnt05Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt04ContactoCliente> Cnt04ContactoClientes { get; } = new List<Cnt04ContactoCliente>();
}
