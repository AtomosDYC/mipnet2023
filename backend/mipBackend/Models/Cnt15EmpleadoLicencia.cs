using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mipBackend.Models;

public partial class cnt15EmpleadoLicencia
{
    public int cnt19llave { get; set; }

    public int cnt12llave { get; set; }

    public int? cnt15AceptaContrato { get; set; }

    public DateTime? cnt15Fechafirma { get; set; }

    public virtual cnt12Empleado cnt12llaveNavigation { get; set; } = null!;

    public virtual cnt19LicenciaCliente cnt19llaveNavigation { get; set; } = null!;
}
