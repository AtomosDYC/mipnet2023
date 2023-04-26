using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lnc05ValorLicencium
{
    public int Lnc05Llave { get; set; }

    public int? Lnc01Llave { get; set; }

    public int? Lnc05Inicio { get; set; }

    public int? Lnc05Termino { get; set; }

    public int? Lnc05Valor { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Lnc01Licencia? Lnc01LlaveNavigation { get; set; }
}
