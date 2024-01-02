using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt11ContactoSegmentacion
{
    public int cnt11llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? per01llave { get; set; }

    public int? cnt05llave { get; set; }

    public int? cnt11activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt08Segmentacion cnt08llaveNavigation { get; set; } = null!;
}
