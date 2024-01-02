using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Pgo01CompraLicencia
{
    public int Pgo1llave { get; set; }

    public int? cnt19llave { get; set; }

    public int? Pgo03llave { get; set; }

    public int? Pgo01activo { get; set; }

    public int? Pgo01TotalCompra { get; set; }

    public DateTime? Fechacompra { get; set; }

    public virtual cnt19LicenciaCliente? cnt19llave1 { get; set; }

    public virtual cnt01CuentaCliente? cnt19llaveNavigation { get; set; }

    public virtual ICollection<Pgo02NotificarPagoLicencia> Pgo02NotificarPagoLicencia { get; } = new List<Pgo02NotificarPagoLicencia>();

    public virtual Pgo03TipoPagoLicencia? Pgo03llaveNavigation { get; set; }
}
