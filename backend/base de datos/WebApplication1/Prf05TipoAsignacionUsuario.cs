using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Prf05TipoAsignacionUsuario
{
    public int Prf05Llave { get; set; }

    public string? Prf05Nombre { get; set; }

    public string? Prf05Descripcion { get; set; }

    public int? Prf05Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
