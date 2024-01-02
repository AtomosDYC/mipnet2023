using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu02Usuario
{
    public Guid userid { get; set; }

    public string? Secu02Usuario1 { get; set; }

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

    public bool? Secu02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Conteo05ControlReserva> Conteo05ControlReservas { get; } = new List<Conteo05ControlReserva>();

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual ICollection<prf01perfil> prf01perfiles { get; } = new List<prf01perfil>();

    public virtual Secu04TipoEncriptacion? Secu04TipoEncriptacionNavigation { get; set; }

    public virtual ICollection<Secu05UsuarioAcceso> Secu05UsuarioAccesos { get; } = new List<Secu05UsuarioAcceso>();

    /*
    public virtual ICollection<Secu06UsuarioRol> Secu06UsuarioRols { get; } = new List<Secu06UsuarioRol>();
    */

    /*
    public virtual ICollection<Secu08UsuarioAplicacion> Secu08UsuarioAplicacions { get; } = new List<Secu08UsuarioAplicacion>();
    */

    public virtual ICollection<Secu10Accesopermitido> Secu10Accesopermitidos { get; } = new List<Secu10Accesopermitido>();
}
