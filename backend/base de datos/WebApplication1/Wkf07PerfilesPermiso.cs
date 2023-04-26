using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Wkf07PerfilesPermiso
{
    public int Wkf06Llave { get; set; }

    public int Wkf05Llave { get; set; }

    public int Wkf07Activo { get; set; }

    public virtual Wkf05TipoPermiso Wkf05LlaveNavigation { get; set; } = null!;

    public virtual Wkf06Perfile Wkf06LlaveNavigation { get; set; } = null!;
}
