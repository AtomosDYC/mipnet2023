using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo02NotificarPagoLicencia
{
    public int Pgo02Llave { get; set; }

    public int? Pgo01Llave { get; set; }

    public int? Pgo02Activo { get; set; }

    public string? Pgo02DocumentoAdjunto { get; set; }

    public DateTime? Fechanotificacionpago { get; set; }

    public virtual Pgo01CompraLicencia? Pgo01LlaveNavigation { get; set; }
}
