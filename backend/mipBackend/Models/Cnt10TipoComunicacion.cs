using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt10TipoComunicacion
{
    public int cnt10llave { get; set; }

    public string? cnt10nombre { get; set; }

    public string? cnt10descripcion { get; set; }

    public int? cnt10activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt06ComunicacionCliente> cnt06ComunicacionClientes { get; } = new List<cnt06ComunicacionCliente>();
}
