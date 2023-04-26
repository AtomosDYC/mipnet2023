using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cnt15EmpleadoLicencium
{
    public int Cnt19Llave { get; set; }

    public int Cnt12Llave { get; set; }

    public int? Cnt15AceptaContrato { get; set; }

    public DateTime? Cnt15Fechafirma { get; set; }

    public virtual Cnt12Empleado Cnt12LlaveNavigation { get; set; } = null!;

    public virtual Cnt19LicenciaCliente Cnt19LlaveNavigation { get; set; } = null!;
}
