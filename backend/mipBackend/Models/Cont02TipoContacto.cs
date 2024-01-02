using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cont02TipoContacto
{
    public int Cont02llave { get; set; }

    public string? Cont02nombre { get; set; }

    public string? Cont02descripcion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual ICollection<Cont01Contacto> Cont01Contactos { get; } = new List<Cont01Contacto>();
}
