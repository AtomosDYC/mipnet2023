using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt01CuentaCliente
{
    public int Cnt01Llave { get; set; }

    public int? Cnt02Llave { get; set; }

    public int? Per01Llave { get; set; }

    public string? Cnt01Nombre { get; set; }

    public int? Cnt03Llave { get; set; }

    public int? Cnt01CuentaSap { get; set; }

    public int? Cnt01NumeroSap { get; set; }

    public DateTime? Cnt01FechaIngresoSap { get; set; }

    public DateTime? Cnt01AnioIngreso { get; set; }

    public int? Cnt01Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt02TipoCuenta? Cnt02LlaveNavigation { get; set; }

    public virtual Cnt03TipoCliente? Cnt03LlaveNavigation { get; set; }

    public virtual ICollection<Cnt04ContactoCliente> Cnt04ContactoClientes { get; } = new List<Cnt04ContactoCliente>();

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; } = new List<Cnt08Segmentacion>();

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; } = new List<Cnt12Empleado>();

    public virtual ICollection<Cnt14ClienteLicencia> Cnt14ClienteLicencia { get; } = new List<Cnt14ClienteLicencia>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();

    public virtual ICollection<Cnt19LicenciaCliente> Cnt19LicenciaClientes { get; } = new List<Cnt19LicenciaCliente>();

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
