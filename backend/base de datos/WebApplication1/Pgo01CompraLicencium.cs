using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Pgo01CompraLicencium
{
    public int Pgo1Llave { get; set; }

    public int? Cnt19Llave { get; set; }

    public int? Pgo03Llave { get; set; }

    public int? Pgo01Activo { get; set; }

    public int? Pgo01TotalCompra { get; set; }

    public DateTime? Fechacompra { get; set; }

    public virtual Cnt19LicenciaCliente? Cnt19Llave1 { get; set; }

    public virtual Cnt01CuentaCliente? Cnt19LlaveNavigation { get; set; }

    public virtual ICollection<Pgo02NotificarPagoLicencium> Pgo02NotificarPagoLicencia { get; set; } = new List<Pgo02NotificarPagoLicencium>();

    public virtual Pgo03TipoPagoLicencium? Pgo03LlaveNavigation { get; set; }
}
