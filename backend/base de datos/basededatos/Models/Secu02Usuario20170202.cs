using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Secu02Usuario20170202
{
    public Guid Secu02Llave { get; set; }

    public string? Secu02Usuario { get; set; }

    public string? Secu02Clave { get; set; }

    public string? Secu02ComplementoClave { get; set; }

    public Guid? Secu04TipoEncriptacion { get; set; }

    public string? Secu02Movil { get; set; }

    public string? Secu02Email { get; set; }

    public string? Secu02Pregunta { get; set; }

    public string? Secu02Respuesta { get; set; }

    public bool? Secu02Bloqueado { get; set; }

    public DateTime? Secu02FechaBloqueo { get; set; }

    public DateTime? Secu02FechaCambioPass { get; set; }

    public bool? Secu02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }
}
