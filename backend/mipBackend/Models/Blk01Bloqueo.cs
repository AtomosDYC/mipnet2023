using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Blk01Bloqueo
{
    public int Blk01llave { get; set; }

    public int? Blk02llave { get; set; }

    public string? Blk01nombreBloqueo { get; set; }

    public string? Blk01descripcion { get; set; }

    public int? Blk01permanente { get; set; }

    public int? Blk01MinDuraciondia { get; set; }

    public int? Blk01MaxDuraciondia { get; set; }

    public int? Blk01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Blk02TipoBloqueo? Blk02llaveNavigation { get; set; }

    public virtual ICollection<Blk03BloqueoUsuario> Blk03BloqueoUsuarios { get; } = new List<Blk03BloqueoUsuario>();

    public virtual ICollection<cnt17Bloqueo> cnt17Bloqueos { get; } = new List<cnt17Bloqueo>();
}
