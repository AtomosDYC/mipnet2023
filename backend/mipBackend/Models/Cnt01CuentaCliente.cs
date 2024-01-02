using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt01CuentaCliente
{
    public int cnt01llave { get; set; }

    public int? cnt02llave { get; set; }

    public int? per01llave { get; set; }

    public string? cnt01nombre { get; set; }

    public int? cnt03llave { get; set; }

    public int? cnt01CuentaSap { get; set; }

    public int? cnt01NumeroSap { get; set; }

    public DateTime? cnt01FechaIngresoSap { get; set; }

    public DateTime? cnt01AnioIngreso { get; set; }

    public int? cnt01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt02TipoCuenta? cnt02llaveNavigation { get; set; }

    public virtual cnt03TipoCliente? cnt03llaveNavigation { get; set; }

    public virtual ICollection<cnt04ContactoCliente> cnt04ContactoClientes { get; } = new List<cnt04ContactoCliente>();

    public virtual ICollection<cnt06ComunicacionCliente> cnt06ComunicacionClientes { get; } = new List<cnt06ComunicacionCliente>();

    public virtual ICollection<cnt08Segmentacion> cnt08Segmentacions { get; } = new List<cnt08Segmentacion>();

    public virtual ICollection<cnt12Empleado> cnt12Empleados { get; } = new List<cnt12Empleado>();

    public virtual ICollection<cnt14ClienteLicencia> cnt14ClienteLicencia { get; } = new List<cnt14ClienteLicencia>();

    public virtual ICollection<cnt17Bloqueo> cnt17Bloqueos { get; } = new List<cnt17Bloqueo>();

    public virtual ICollection<cnt19LicenciaCliente> cnt19LicenciaClientes { get; } = new List<cnt19LicenciaCliente>();

    public virtual per01persona? per01llaveNavigation { get; set; }

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
