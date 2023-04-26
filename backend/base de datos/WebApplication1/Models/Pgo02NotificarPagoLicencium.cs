using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Pgo02NotificarPagoLicencium
{
    public int Pgo02Llave { get; set; }

    public int? Pgo01Llave { get; set; }

    public int? Pgo02Activo { get; set; }

    public string? Pgo02DocumentoAdjunto { get; set; }

    public DateTime? Fechanotificacionpago { get; set; }

    public virtual Pgo01CompraLicencium? Pgo01LlaveNavigation { get; set; }
}
