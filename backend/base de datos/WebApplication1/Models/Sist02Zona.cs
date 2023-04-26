using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sist02Zona
{
    public int Sist02Llave { get; set; }

    public string? Sist02Nombre { get; set; }

    public string? Sist02Descripcion { get; set; }

    public string? Sist02Estadoregistro { get; set; }

    public int? Sist02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Sist03Comuna> Sist03Llaves { get; set; } = new List<Sist03Comuna>();
}
