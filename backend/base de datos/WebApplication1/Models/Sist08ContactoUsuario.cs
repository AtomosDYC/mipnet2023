using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Sist08ContactoUsuario
{
    public int Sist08Llave { get; set; }

    public int? Per02Llave { get; set; }

    public string? Sist08Nombre { get; set; }

    public string? Sist08Empresa { get; set; }

    public string? Sist08Correo { get; set; }

    public string? Sist08Comentario { get; set; }

    public string? Sist08Telefono { get; set; }

    public string? Sist08Celular { get; set; }

    public int? Sist08Estado { get; set; }

    public DateTime? Sist08Fechacreacion { get; set; }

    public virtual Per02Genero? Per02LlaveNavigation { get; set; }
}
