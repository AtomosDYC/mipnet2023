using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Pgo02NotificarPagoLicencium
{
    public decimal Pgo02Llave { get; set; }

    public decimal? Pgo01Llave { get; set; }

    public int? Pgo02Activo { get; set; }

    public string? Pgo02DocumentoAdjunto { get; set; }

    public DateTime? Fechanotificacionpago { get; set; }

    public virtual Pgo01CompraLicencium? Pgo01LlaveNavigation { get; set; }
}
