using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Esp11ReglaGrafico
{
    public int Esp11Llave { get; set; }

    public int? Esp03Llave { get; set; }

    public int? Esp10Llave { get; set; }

    public string? Esp11Nombre { get; set; }

    public string? Esp11Signo1 { get; set; }

    public int? Esp11Valor1 { get; set; }

    public string? Esp11Signo2 { get; set; }

    public int? Esp11Valor2 { get; set; }

    public string? Esp11SignoResultado { get; set; }

    public int? Esp11ValorResultado { get; set; }

    public int? Esp11Estado { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Esp10TipoRegla? Esp10LlaveNavigation { get; set; }
}
