﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Secu03TipoAcceso
{
    public Guid Secu03Llave { get; set; }

    public string? Secu03Nombre { get; set; }

    public string? Secu03Descripcion { get; set; }

    public string? Secu03Info { get; set; }

    public bool? Secu03Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public virtual ICollection<Secu05UsuarioAcceso> Secu05UsuarioAccesos { get; set; } = new List<Secu05UsuarioAcceso>();

    public virtual ICollection<Secu10AccesoPermitido> Secu10AccesoPermitidos { get; set; } = new List<Secu10AccesoPermitido>();
}
