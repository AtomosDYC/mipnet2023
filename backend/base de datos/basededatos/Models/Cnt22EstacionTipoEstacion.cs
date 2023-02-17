using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt22EstacionTipoEstacion
{
    public decimal Cnt08Llave { get; set; }

    public decimal Cnt21Llave { get; set; }

    public int? Cnt22Estado { get; set; }

    public virtual Cnt08Segmentacion Cnt08LlaveNavigation { get; set; } = null!;

    public virtual Cnt21TipoEstacion Cnt21LlaveNavigation { get; set; } = null!;
}
