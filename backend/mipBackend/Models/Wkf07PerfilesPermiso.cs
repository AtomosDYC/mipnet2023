using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Wkf07PerfilesPermiso
{
    public int wkf06llave { get; set; }

    public int wkf05llave { get; set; }

    public int wkf07activo { get; set; }

    public virtual Wkf05TipoPermiso Wkf05LlaveNavigation { get; set; } = null!;

    public virtual Wkf06Perfil Wkf06LlaveNavigation { get; set; } = null!;
}
