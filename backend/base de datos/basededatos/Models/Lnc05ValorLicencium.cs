using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Lnc05ValorLicencium
{
    public decimal Lnc05Llave { get; set; }

    public decimal? Lnc01Llave { get; set; }

    public decimal? Lnc05Inicio { get; set; }

    public decimal? Lnc05Termino { get; set; }

    public decimal? Lnc05Valor { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public Guid? CreateBy { get; set; }

    public virtual Lnc01Licencia? Lnc01LlaveNavigation { get; set; }
}
