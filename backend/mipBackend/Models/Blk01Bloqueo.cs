using System;
using System.Collections.Generic;

namespace mipBackend.Models;

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

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Blk02TipoBloqueo? Blk02LlaveNavigation { get; set; }

    public virtual ICollection<Blk03BloqueoUsuario> Blk03BloqueoUsuarios { get; } = new List<Blk03BloqueoUsuario>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();
}
