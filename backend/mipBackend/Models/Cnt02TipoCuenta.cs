using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt02TipoCuenta
{
    public int cnt02llave { get; set; }

    public string? cnt02nombre { get; set; }

    public string? cnt02descripcion { get; set; }

    public int? cnt02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt01CuentaCliente> cnt01CuentaClientes { get; } = new List<cnt01CuentaCliente>();
}
