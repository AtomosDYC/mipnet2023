using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt05TipoContacto
{
    public int cnt05llave { get; set; }

    public string? cnt05nombre { get; set; }

    public string? cnt05descripcion { get; set; }

    public int? cnt05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt04ContactoCliente> cnt04ContactoClientes { get; } = new List<cnt04ContactoCliente>();
}
