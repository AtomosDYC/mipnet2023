using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mvl03RegistroAcceso
{
    public int Mvl03llave { get; set; }

    public Guid? ApplicationId { get; set; }

    public Guid? UserId { get; set; }

    public int? per01llave { get; set; }

    public string? UserName { get; set; }

    public string? LoweredUserName { get; set; }

    public string? MobileAlias { get; set; }

    public string? IsAnonymous { get; set; }

    public string? LastActivityDate { get; set; }

    public string? Password { get; set; }

    public string? PasswordFormat { get; set; }

    public Guid? PasswordSalt { get; set; }

    public string? Email { get; set; }

    public bool? IsApproved { get; set; }

    public bool? Secu02activo { get; set; }

    public string? nombreUsuario { get; set; }

    public string? EmailUsuario { get; set; }

    public int? EstadoUsuario { get; set; }

    public DateTime? Mvl03Fechacreacion { get; set; }
}
