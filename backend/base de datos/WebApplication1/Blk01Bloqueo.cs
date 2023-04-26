using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Blk01Bloqueo
{
    public int Blk01Llave { get; set; }

    public int? Blk02Llave { get; set; }

    public string? Blk01NombreBloqueo { get; set; }

    public string? Blk01Descripcion { get; set; }

    public int? Blk01Permanente { get; set; }

    public int? Blk01MinDuraciondia { get; set; }

    public int? Blk01MaxDuraciondia { get; set; }

    public int? Blk01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Blk02TipoBloqueo? Blk02LlaveNavigation { get; set; }

    public virtual ICollection<Blk03BloqueoUsuario> Blk03BloqueoUsuarios { get; set; } = new List<Blk03BloqueoUsuario>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; set; } = new List<Cnt17Bloqueo>();
}
