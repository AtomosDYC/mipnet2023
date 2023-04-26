using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Wkf04NivelPermiso
{
    public int Wkf04Llave { get; set; }

    public int? Wkf03Llave { get; set; }

    public int? Wkf05Llave { get; set; }

    public int? Wkf04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Wkf03Nivel? Wkf03LlaveNavigation { get; set; }

    public virtual Wkf05TipoPermiso? Wkf05LlaveNavigation { get; set; }
}
