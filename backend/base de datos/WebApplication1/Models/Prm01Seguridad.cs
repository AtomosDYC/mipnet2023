using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Prm01Seguridad
{
    public int Prm01Llave { get; set; }

    public string? Prm01Nombre { get; set; }

    public string? Prm01Descripcion { get; set; }

    public int? Prm01Valor { get; set; }

    public string? Prm01UrlError { get; set; }

    public int? Prm01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
