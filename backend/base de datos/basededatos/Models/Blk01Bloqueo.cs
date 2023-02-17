using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Blk01Bloqueo
{
    public decimal Blk01Llave { get; set; }

    public decimal? Blk02Llave { get; set; }

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

    public virtual ICollection<Blk03BloqueoUsuario> Blk03BloqueoUsuarios { get; } = new List<Blk03BloqueoUsuario>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
