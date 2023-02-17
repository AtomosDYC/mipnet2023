using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt03TipoCliente
{
    public decimal Cnt03Llave { get; set; }

    public decimal? Per03Llave { get; set; }

    public string? Cnt03Nombre { get; set; }

    public string? Cnt03Descripcion { get; set; }

    public decimal? Cnt03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; } = new List<Cnt01CuentaCliente>();

    public virtual Per03TipoPersona? Per03LlaveNavigation { get; set; }
}
