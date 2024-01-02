using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Blk03BloqueoUsuario
{
    public int Blk03llave { get; set; }

    public int? Blk01llave { get; set; }

    public Guid? userid { get; set; }

    public DateTime? Blk03FechaInicio { get; set; }

    public DateTime? Blk03FechaTermino { get; set; }

    public int? Blk03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Blk01Bloqueo? Blk01llaveNavigation { get; set; }
}
