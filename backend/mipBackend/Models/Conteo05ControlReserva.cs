using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Conteo05ControlReserva
{
    public int Conteo05Llave { get; set; }

    public string? Conteo05TablaControl { get; set; }

    public string? Conteo05ColumnaControl { get; set; }

    public int? Conteo05ValorControl { get; set; }

    public string? Conteo05IdMovil { get; set; }

    public Guid? Secu02Llave { get; set; }

    public int? Conteo05EstadoControl { get; set; }

    public bool? Conteo05Estado { get; set; }

    public string? Conteo05Primer { get; set; }

    public string? Conteo05Segundo { get; set; }

    public string? Conteo05Tercer { get; set; }

    public DateTime? Conteo05Fecha { get; set; }

    public DateTime fechaactualizacion { get; set; }

    public virtual Secu02Usuario? Secu02LlaveNavigation { get; set; }
}
