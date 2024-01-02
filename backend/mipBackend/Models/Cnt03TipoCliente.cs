using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt03TipoCliente
{
    public int cnt03llave { get; set; }

    public int? per03llave { get; set; }

    public string? cnt03nombre { get; set; }

    public string? cnt03descripcion { get; set; }

    public int? cnt03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt01CuentaCliente> cnt01CuentaClientes { get; } = new List<cnt01CuentaCliente>();

    public virtual per03Tipopersona? per03llaveNavigation { get; set; }
}
