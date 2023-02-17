using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cont02TipoContacto
{
    public int Cont02Llave { get; set; }

    public string? Cont02Nombre { get; set; }

    public string? Cont02Descripcion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual ICollection<Cont01Contacto> Cont01Contactos { get; } = new List<Cont01Contacto>();
}
