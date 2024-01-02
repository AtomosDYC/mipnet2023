using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu04TipoEncriptacion
{
    public Guid Secu04llave { get; set; }

    public string? Secu04nombre { get; set; }

    public string? Secu04Proyecto { get; set; }

    public string? Secu04Clase { get; set; }

    public string? Secu04Funcion { get; set; }

    public string? Secu04Parametros { get; set; }

    public string? Secu04Info { get; set; }

    public bool? Secu04activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Secu02Usuario> Secu02Usuarios { get; } = new List<Secu02Usuario>();
}
