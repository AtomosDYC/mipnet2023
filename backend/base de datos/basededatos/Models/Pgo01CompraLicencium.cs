using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Pgo01CompraLicencium
{
    public decimal Pgo1Llave { get; set; }

    public decimal? Cnt19Llave { get; set; }

    public decimal? Pgo03Llave { get; set; }

    public int? Pgo01Activo { get; set; }

    public decimal? Pgo01TotalCompra { get; set; }

    public DateTime? Fechacompra { get; set; }

    public virtual Cnt19LicenciaCliente? Cnt19Llave1 { get; set; }

    public virtual Cnt01CuentaCliente? Cnt19LlaveNavigation { get; set; }

    public virtual ICollection<Pgo02NotificarPagoLicencium> Pgo02NotificarPagoLicencia { get; } = new List<Pgo02NotificarPagoLicencium>();

    public virtual Pgo03TipoPagoLicencium? Pgo03LlaveNavigation { get; set; }
}
