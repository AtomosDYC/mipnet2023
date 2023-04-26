using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Per08TipoDocumento
{
    public int Per08Llave { get; set; }

    public string? Per08Nombre { get; set; }

    public string? Per08Descripcion { get; set; }

    public int? Per08Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
