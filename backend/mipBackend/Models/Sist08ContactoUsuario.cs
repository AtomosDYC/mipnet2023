using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class sist08ContactoUsuario
{
    public int sist08llave { get; set; }

    public int? per02llave { get; set; }

    public string? sist08nombre { get; set; }

    public string? sist08Empresa { get; set; }

    public string? sist08Correo { get; set; }

    public string? sist08Comentario { get; set; }

    public string? sist08Telefono { get; set; }

    public string? sist08Celular { get; set; }

    public int? sist08Estado { get; set; }

    public DateTime? sist08Fechacreacion { get; set; }

    public virtual per02Genero? per02llaveNavigation { get; set; }
}
