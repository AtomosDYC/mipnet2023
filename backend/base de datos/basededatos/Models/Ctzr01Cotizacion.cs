using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Ctzr01Cotizacion
{
    public decimal Ctzr01Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public decimal? Lnc01Llave { get; set; }

    public DateTime? Ctzr01Fecha { get; set; }

    public string? Ctzr01Comentario { get; set; }

    public int? Ctzr01Activo { get; set; }
}
