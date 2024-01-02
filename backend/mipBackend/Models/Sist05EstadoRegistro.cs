using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class sist05EstadoRegistro
{
    public int sist05llave { get; set; }

    public string? sist05nombre { get; set; }

    public string? sist03descripcion { get; set; }

    public int? sist03activo { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public virtual ICollection<Ins02RecuperarClave> Ins02RecuperarClaves { get; } = new List<Ins02RecuperarClave>();
}
