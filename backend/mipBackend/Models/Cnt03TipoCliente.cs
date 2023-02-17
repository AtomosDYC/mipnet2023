using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt03TipoCliente
{
    public int Cnt03Llave { get; set; }

    public int? Per03Llave { get; set; }

    public string? Cnt03Nombre { get; set; }

    public string? Cnt03Descripcion { get; set; }

    public int? Cnt03Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; } = new List<Cnt01CuentaCliente>();

    public virtual Per03TipoPersona? Per03LlaveNavigation { get; set; }
}
