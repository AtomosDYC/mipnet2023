using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Per02Genero
{
    public decimal Per02Llave { get; set; }

    public string? Per02Titulo { get; set; }

    public string? Per02Genero1 { get; set; }

    public string? Per02Sexo { get; set; }

    public decimal? Per02Orden { get; set; }

    public int? Per02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

    public virtual ICollection<Sist08ContactoUsuario> Sist08ContactoUsuarios { get; } = new List<Sist08ContactoUsuario>();
}
