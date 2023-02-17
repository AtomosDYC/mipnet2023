using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt12Empleado
{
    public int Cnt12Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Per01Llave { get; set; }

    public int? Cnt08Llave { get; set; }

    public int? Cnt13Llave { get; set; }

    public string? Cnt12Cargo { get; set; }

    public int? Cnt12Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual Cnt13TipoEmpleado? Cnt13LlaveNavigation { get; set; }

    public virtual ICollection<Cnt15EmpleadoLicencia> Cnt15EmpleadoLicencia { get; } = new List<Cnt15EmpleadoLicencia>();

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }
}
