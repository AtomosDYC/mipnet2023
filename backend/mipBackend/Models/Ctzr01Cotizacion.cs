using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Ctzr01Cotizacion
{
    public int Ctzr01llave { get; set; }

    public Guid? userid { get; set; }

    public int? Lnc01llave { get; set; }

    public DateTime? Ctzr01Fecha { get; set; }

    public string? Ctzr01Comentario { get; set; }

    public int? Ctzr01activo { get; set; }
}
