using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf07perfilespermiso
{
    public int wkf06llave { get; set; }

    public int wkf05llave { get; set; }

    public int wkf07activo { get; set; }

    public virtual wkf05Tipopermiso wkf05llaveNavigation { get; set; } = null!;

    public virtual wkf06perfil wkf06llaveNavigation { get; set; } = null!;
}
