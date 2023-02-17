using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Sist05EstadoRegistro
{
    public int Sist05Llave { get; set; }

    public string? Sist05Nombre { get; set; }

    public string? Sist03Descripcion { get; set; }

    public int? Sist03Activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public virtual ICollection<Ins02RecuperarClave> Ins02RecuperarClaves { get; } = new List<Ins02RecuperarClave>();
}
