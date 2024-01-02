using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt12Empleado
{
    public int cnt12llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? per01llave { get; set; }

    public int? cnt08llave { get; set; }

    public int? cnt13llave { get; set; }

    public string? cnt12Cargo { get; set; }

    public int? cnt12activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt01CuentaCliente? cnt01llaveNavigation { get; set; }

    public virtual cnt13TipoEmpleado? cnt13llaveNavigation { get; set; }

    public virtual ICollection<cnt15EmpleadoLicencia> cnt15EmpleadoLicencia { get; } = new List<cnt15EmpleadoLicencia>();

    public virtual per01persona? per01llaveNavigation { get; set; }
}
