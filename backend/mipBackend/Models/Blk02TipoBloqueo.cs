using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Blk02TipoBloqueo
{
    public int Blk02Llave { get; set; }

    public string? Blk02Nombre { get; set; }

    public string? Blk02Descripcion { get; set; }

    public int? Blk02Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Blk01Bloqueo> Blk01Bloqueos { get; } = new List<Blk01Bloqueo>();
}
