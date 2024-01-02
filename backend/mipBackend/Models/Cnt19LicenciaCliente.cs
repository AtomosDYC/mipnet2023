using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt19LicenciaCliente
{
    public int cnt19llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? Lnc01llave { get; set; }

    public string? cnt19nombreLicencia { get; set; }

    public int? cnt19NumeroUsuario { get; set; }

    public int? cnt19NumeroDias { get; set; }

    public DateTime? cnt19FechaInicio { get; set; }

    public DateTime? cnt19FechaTermino { get; set; }

    public int? cnt19activo { get; set; }

    public int? cnt23llave { get; set; }

    public int? cnt19ValorReferencial { get; set; }

    public int? Temp02llave { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt01CuentaCliente? cnt01llaveNavigation { get; set; }

    public virtual ICollection<cnt15EmpleadoLicencia> cnt15EmpleadoLicencia { get; } = new List<cnt15EmpleadoLicencia>();

    public virtual ICollection<cnt20LicenciaServicio> cnt20LicenciaServicios { get; } = new List<cnt20LicenciaServicio>();

    public virtual ICollection<Pgo01CompraLicencia> Pgo01CompraLicencia { get; } = new List<Pgo01CompraLicencia>();
}
