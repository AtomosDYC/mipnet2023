using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt21TipoEstacion
{
    public int Cnt21Llave { get; set; }

    public string? Cnt21Nombre { get; set; }

    public string? Cnt21Descripcion { get; set; }

    public int? Cnt21Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt22EstacionTipoEstacion> Cnt22EstacionTipoEstacions { get; } = new List<Cnt22EstacionTipoEstacion>();
}
