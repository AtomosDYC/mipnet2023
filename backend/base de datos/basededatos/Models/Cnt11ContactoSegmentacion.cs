using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt11ContactoSegmentacion
{
    public decimal Cnt11Llave { get; set; }

    public decimal Cnt08Llave { get; set; }

    public decimal? Per01Llave { get; set; }

    public decimal? Cnt05Llave { get; set; }

    public int? Cnt11Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt08Segmentacion Cnt08LlaveNavigation { get; set; } = null!;
}
