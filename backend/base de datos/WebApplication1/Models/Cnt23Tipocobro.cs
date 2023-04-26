using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cnt23Tipocobro
{
    public int Cnt23Llave { get; set; }

    public string? Cnt23Nombre { get; set; }

    public string? Cnt23Descripcion { get; set; }

    public int? Cnt23Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
