using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt13TipoEmpleado
{
    public int Cnt13Llave { get; set; }

    public string? Cnt13Nombre { get; set; }

    public string? Cnt13Descripcion { get; set; }

    public int? Cnt13Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; } = new List<Cnt12Empleado>();
}
