using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt21TipoEstacion
{
    public int cnt21llave { get; set; }

    public string? cnt21nombre { get; set; }

    public string? cnt21descripcion { get; set; }

    public int? cnt21activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt22EstacionTipoEstacion> cnt22EstacionTipoEstacions { get; } = new List<cnt22EstacionTipoEstacion>();
}
