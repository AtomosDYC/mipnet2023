using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Blk03BloqueoUsuario
{
    public int Blk03Llave { get; set; }

    public int? Blk01Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public DateTime? Blk03FechaInicio { get; set; }

    public DateTime? Blk03FechaTermino { get; set; }

    public int? Blk03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Blk01Bloqueo? Blk01LlaveNavigation { get; set; }
}
