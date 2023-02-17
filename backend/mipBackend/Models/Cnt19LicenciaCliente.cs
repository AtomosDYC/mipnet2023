using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt19LicenciaCliente
{
    public int Cnt19Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Lnc01Llave { get; set; }

    public string? Cnt19NombreLicencia { get; set; }

    public int? Cnt19NumeroUsuario { get; set; }

    public int? Cnt19NumeroDias { get; set; }

    public DateTime? Cnt19FechaInicio { get; set; }

    public DateTime? Cnt19FechaTermino { get; set; }

    public int? Cnt19Activo { get; set; }

    public int? Cnt23Llave { get; set; }

    public int? Cnt19ValorReferencial { get; set; }

    public int? Temp02Llave { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual ICollection<Cnt15EmpleadoLicencia> Cnt15EmpleadoLicencia { get; } = new List<Cnt15EmpleadoLicencia>();

    public virtual ICollection<Cnt20LicenciaServicio> Cnt20LicenciaServicios { get; } = new List<Cnt20LicenciaServicio>();

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
