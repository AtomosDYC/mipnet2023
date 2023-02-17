using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Lnc05ValorLicencia
{
    public int Lnc05Llave { get; set; }

    public int? Lnc01Llave { get; set; }

    public int? Lnc05Inicio { get; set; }

    public int? Lnc05Termino { get; set; }

    public int? Lnc05Valor { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public Guid? createby { get; set; }

    public virtual Lnc01Licencia? Lnc01LlaveNavigation { get; set; }
}
