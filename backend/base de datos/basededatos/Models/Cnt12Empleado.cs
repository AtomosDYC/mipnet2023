using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt12Empleado
{
    public decimal Cnt12Llave { get; set; }

    public decimal? Cnt01Llave { get; set; }

    public decimal? Per01Llave { get; set; }

    public decimal? Cnt08Llave { get; set; }

    public decimal? Cnt13Llave { get; set; }

    public string? Cnt12Cargo { get; set; }

    public int? Cnt12Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual Cnt13TipoEmpleado? Cnt13LlaveNavigation { get; set; }

    public virtual ICollection<Cnt15EmpleadoLicencium> Cnt15EmpleadoLicencia { get; } = new List<Cnt15EmpleadoLicencium>();

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }
}
