using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Blk02TipoBloqueo
{
    public int Blk02Llave { get; set; }

    public string? Blk02Nombre { get; set; }

    public string? Blk02Descripcion { get; set; }

    public int? Blk02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Blk01Bloqueo> Blk01Bloqueos { get; set; } = new List<Blk01Bloqueo>();
}
