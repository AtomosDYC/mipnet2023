using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Secu07Aplicacion
{
    public Guid Secu07Llave { get; set; }

    public string? Secu07Nombre { get; set; }

    public string? Secu07Descripcion { get; set; }

    public string? Secu07Info { get; set; }

    public bool? Secu07Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }
}
