using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt22EstacionTipoEstacion
{
    public int cnt08llave { get; set; }

    public int cnt21llave { get; set; }

    public int? cnt22Estado { get; set; }

    public virtual cnt08Segmentacion cnt08llaveNavigation { get; set; } = null!;

    public virtual cnt21TipoEstacion cnt21llaveNavigation { get; set; } = null!;
}
