using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt01CuentaCliente
{
    public decimal Cnt01Llave { get; set; }

    public decimal? Cnt02Llave { get; set; }

    public decimal? Per01Llave { get; set; }

    public string? Cnt01Nombre { get; set; }

    public decimal? Cnt03Llave { get; set; }

    public int? Cnt01CuentaSap { get; set; }

    public int? Cnt01NumeroSap { get; set; }

    public DateTime? Cnt01FechaIngresoSap { get; set; }

    public DateTime? Cnt01AnioIngreso { get; set; }

    public int? Cnt01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt02TipoCuentum? Cnt02LlaveNavigation { get; set; }

    public virtual Cnt03TipoCliente? Cnt03LlaveNavigation { get; set; }

    public virtual ICollection<Cnt04ContactoCliente> Cnt04ContactoClientes { get; } = new List<Cnt04ContactoCliente>();

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; } = new List<Cnt08Segmentacion>();

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; } = new List<Cnt12Empleado>();

    public virtual ICollection<Cnt14ClienteLicencium> Cnt14ClienteLicencia { get; } = new List<Cnt14ClienteLicencium>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();

    public virtual ICollection<Cnt19LicenciaCliente> Cnt19LicenciaClientes { get; } = new List<Cnt19LicenciaCliente>();

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }

    public virtual ICollection<Pgo01CompraLicencium> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencium>();
}
