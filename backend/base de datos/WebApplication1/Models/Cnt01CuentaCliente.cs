using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt02TipoCuentum? Cnt02LlaveNavigation { get; set; }

    public virtual Cnt03TipoCliente? Cnt03LlaveNavigation { get; set; }

    public virtual ICollection<Cnt04ContactoCliente> Cnt04ContactoClientes { get; set; } = new List<Cnt04ContactoCliente>();

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; set; } = new List<Cnt06ComunicacionCliente>();

    public virtual ICollection<Cnt08Segmentacion> Cnt08Segmentacions { get; set; } = new List<Cnt08Segmentacion>();

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; set; } = new List<Cnt12Empleado>();

    public virtual ICollection<Cnt14ClienteLicencium> Cnt14ClienteLicencia { get; set; } = new List<Cnt14ClienteLicencium>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; set; } = new List<Cnt17Bloqueo>();

    public virtual ICollection<Cnt19LicenciaCliente> Cnt19LicenciaClientes { get; set; } = new List<Cnt19LicenciaCliente>();

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }

    public virtual ICollection<Pgo01CompraLicencium> Pgo01CompraLicencia { get; set; } = new List<Pgo01CompraLicencium>();
}
