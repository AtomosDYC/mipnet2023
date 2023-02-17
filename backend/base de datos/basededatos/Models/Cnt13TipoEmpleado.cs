using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cnt13TipoEmpleado
{
    public decimal Cnt13Llave { get; set; }

    public string? Cnt13Nombre { get; set; }

    public string? Cnt13Descripcion { get; set; }

    public int? Cnt13Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Cnt12Empleado> Cnt12Empleados { get; } = new List<Cnt12Empleado>();
}
