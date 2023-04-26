using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Secu02Usuario
{
    public Guid Secu02Llave { get; set; }

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

    public bool? Secu02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public virtual ICollection<Conteo05ControlReserva> Conteo05ControlReservas { get; set; } = new List<Conteo05ControlReserva>();

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; set; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual ICollection<Prf01Perfile> Prf01Perfiles { get; set; } = new List<Prf01Perfile>();

    public virtual Secu04TipoEncriptacion? Secu04TipoEncriptacionNavigation { get; set; }

    public virtual ICollection<Secu05UsuarioAcceso> Secu05UsuarioAccesos { get; set; } = new List<Secu05UsuarioAcceso>();

    public virtual ICollection<Secu06UsuarioRol> Secu06UsuarioRols { get; set; } = new List<Secu06UsuarioRol>();

    public virtual ICollection<Secu08UsuarioAplicacion> Secu08UsuarioAplicacions { get; set; } = new List<Secu08UsuarioAplicacion>();

    public virtual ICollection<Secu10AccesoPermitido> Secu10AccesoPermitidos { get; set; } = new List<Secu10AccesoPermitido>();
}
