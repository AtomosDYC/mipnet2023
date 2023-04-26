using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cnt02TipoCuentum
{
    public int Cnt02Llave { get; set; }

    public string? Cnt02Nombre { get; set; }

    public string? Cnt02Descripcion { get; set; }

    public int? Cnt02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt01CuentaCliente> Cnt01CuentaClientes { get; set; } = new List<Cnt01CuentaCliente>();
}
