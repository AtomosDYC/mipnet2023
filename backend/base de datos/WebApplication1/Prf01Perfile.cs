using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Prf01Perfile
{
    public int Prf01Llave { get; set; }

    public int? Prf03Llave { get; set; }

    public string? UsrId { get; set; }

    public int? Prf01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Prf03Plantilla? Prf03LlaveNavigation { get; set; }

    public virtual AspNetUser? Usr { get; set; }
}
