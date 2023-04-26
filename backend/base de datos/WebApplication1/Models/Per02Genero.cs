using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Per02Genero
{
    public int Per02Llave { get; set; }

    public string? Per02Titulo { get; set; }

    public int? Per02Orden { get; set; }

    public int? Per02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Per01Persona> Per01Personas { get; set; } = new List<Per01Persona>();

    public virtual ICollection<Sist08ContactoUsuario> Sist08ContactoUsuarios { get; set; } = new List<Sist08ContactoUsuario>();
}
