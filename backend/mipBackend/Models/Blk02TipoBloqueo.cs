using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Blk02TipoBloqueo
{
    public int Blk02llave { get; set; }

    public string? Blk02nombre { get; set; }

    public string? Blk02descripcion { get; set; }

    public int? Blk02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Blk01Bloqueo> Blk01Bloqueos { get; } = new List<Blk01Bloqueo>();
}
