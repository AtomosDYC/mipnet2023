using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu05UsuarioAcceso
{
    public Guid Secu05llave { get; set; }

    public Guid? userid { get; set; }

    public Guid? Secu03TipoAcceso { get; set; }

    public string? Secu05llaveAcceso { get; set; }

    public string? Secu05Soacceso { get; set; }

    public string? Secu05VersionActual { get; set; }

    public string? Secu05VersionDescarga { get; set; }

    public bool? Secu05ForzarDescarga { get; set; }

    public DateTime? Secu05FechaUltAcceso { get; set; }

    public DateTime? Secu05FechaUltActividad { get; set; }

    public DateTime? Secu05FechaUltDescarga { get; set; }

    public bool? Secu05Bloqueado { get; set; }

    public DateTime? Secu05FechaBloqueo { get; set; }

    public string? Secu05Mensaje { get; set; }

    public DateTime? Secu05FechaMensaje { get; set; }

    public string? Secu05Info { get; set; }

    public bool? Secu05activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual Secu02Usuario? useridNavigation { get; set; }

    public virtual Secu03TipoAcceso? Secu03TipoAccesoNavigation { get; set; }
}
