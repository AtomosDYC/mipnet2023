using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Inmueble
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int Precio { get; set; }

    public string? Picture { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public Guid? UsuarioId { get; set; }
}
