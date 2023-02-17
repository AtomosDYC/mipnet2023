using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt10TipoComunicacion
{
    public decimal Cnt10Llave { get; set; }

    public string? Cnt10Nombre { get; set; }

    public string? Cnt10Descripcion { get; set; }

    public int? Cnt10Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();
}
