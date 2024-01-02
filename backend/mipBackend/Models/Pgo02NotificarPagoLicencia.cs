using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo02NotificarPagoLicencia
{
    public int Pgo02llave { get; set; }

    public int? Pgo01llave { get; set; }

    public int? Pgo02activo { get; set; }

    public string? Pgo02DocumentoAdjunto { get; set; }

    public DateTime? Fechanotificacionpago { get; set; }

    public virtual Pgo01CompraLicencia? Pgo01llaveNavigation { get; set; }
}
