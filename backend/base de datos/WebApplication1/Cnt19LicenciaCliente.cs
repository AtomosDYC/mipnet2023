using System;
using System.Collections.Generic;

namespace WebApplication1;

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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual ICollection<Cnt15EmpleadoLicencium> Cnt15EmpleadoLicencia { get; set; } = new List<Cnt15EmpleadoLicencium>();

    public virtual ICollection<Cnt20LicenciaServicio> Cnt20LicenciaServicios { get; set; } = new List<Cnt20LicenciaServicio>();

    public virtual ICollection<Pgo01CompraLicencium> Pgo01CompraLicencia { get; set; } = new List<Pgo01CompraLicencium>();
}
