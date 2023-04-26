using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Cont02TipoContacto
{
    public int Cont02Llave { get; set; }

    public string? Cont02Nombre { get; set; }

    public string? Cont02Descripcion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual ICollection<Cont01Contacto> Cont01Contactos { get; set; } = new List<Cont01Contacto>();
}
