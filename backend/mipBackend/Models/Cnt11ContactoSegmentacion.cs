using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt11ContactoSegmentacion
{
    public int Cnt11Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Per01Llave { get; set; }

    public int? Cnt05Llave { get; set; }

    public int? Cnt11Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt08Segmentacion Cnt08LlaveNavigation { get; set; } = null!;
}
