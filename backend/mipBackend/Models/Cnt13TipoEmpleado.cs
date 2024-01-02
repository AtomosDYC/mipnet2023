using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt13TipoEmpleado
{
    public int cnt13llave { get; set; }

    public string? cnt13nombre { get; set; }

    public string? cnt13descripcion { get; set; }

    public int? cnt13activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt12Empleado> cnt12Empleados { get; } = new List<cnt12Empleado>();
}
