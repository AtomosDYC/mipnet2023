using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Sist05EstadoRegistro
{
    public int Sist05Llave { get; set; }

    public string? Sist05Nombre { get; set; }

    public string? Sist03Descripcion { get; set; }

    public int? Sist03Activo { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public virtual ICollection<Ins02RecuperarClave> Ins02RecuperarClaves { get; } = new List<Ins02RecuperarClave>();
}
