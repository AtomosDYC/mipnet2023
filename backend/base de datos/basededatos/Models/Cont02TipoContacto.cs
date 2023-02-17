using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Cont02TipoContacto
{
    public decimal Cont02Llave { get; set; }

    public string? Cont02Nombre { get; set; }

    public string? Cont02Descripcion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual ICollection<Cont01Contacto> Cont01Contactos { get; } = new List<Cont01Contacto>();
}
