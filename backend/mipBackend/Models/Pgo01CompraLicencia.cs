using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo01CompraLicencia
{
    public int Pgo1Llave { get; set; }

    public int? Cnt19Llave { get; set; }

    public int? Pgo03Llave { get; set; }

    public int? Pgo01Activo { get; set; }

    public int? Pgo01TotalCompra { get; set; }

    public DateTime? Fechacompra { get; set; }

    public virtual Cnt19LicenciaCliente? Cnt19Llave1 { get; set; }

    public virtual Cnt01CuentaCliente? Cnt19LlaveNavigation { get; set; }

    public virtual ICollection<Pgo02NotificarPagoLicencia> Pgo02NotificarPagoLicencia { get; } = new List<Pgo02NotificarPagoLicencia>();

    public virtual Pgo03TipoPagoLicencia? Pgo03LlaveNavigation { get; set; }
}
