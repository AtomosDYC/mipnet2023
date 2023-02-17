﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Secu03TipoAcceso
{
    public Guid Secu03Llave { get; set; }

    public string? Secu03Nombre { get; set; }

    public string? Secu03Descripcion { get; set; }

    public string? Secu03Info { get; set; }

    public bool? Secu03Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public virtual ICollection<Secu05UsuarioAcceso> Secu05UsuarioAccesos { get; } = new List<Secu05UsuarioAcceso>();

    public virtual ICollection<Secu10AccesoPermitido> Secu10AccesoPermitidos { get; } = new List<Secu10AccesoPermitido>();
}