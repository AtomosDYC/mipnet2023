using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cnt03TipoCliente
{
    public int Cnt03Llave { get; set; }

    public int? Per03Llave { get; set; }

    public string? Cnt03Nombre { get; set; }

    public string? Cnt03Descripcion { get; set; }

    public int? Cnt03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; set; } = new List<Cnt01CuentaCliente>();

    public virtual Per03TipoPersona? Per03LlaveNavigation { get; set; }
}
