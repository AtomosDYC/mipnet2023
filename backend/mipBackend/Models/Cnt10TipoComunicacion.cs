using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt10TipoComunicacion
{
    public int Cnt10Llave { get; set; }

    public string? Cnt10Nombre { get; set; }

    public string? Cnt10Descripcion { get; set; }

    public int? Cnt10Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();
}
