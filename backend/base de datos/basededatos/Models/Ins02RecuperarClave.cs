using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Ins02RecuperarClave
{
    public decimal Ins02Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public string? Ins02ClaveTemporal { get; set; }

    public DateTime? Ins02FechaRecupera { get; set; }

    public int? Ins02Estado { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Sist05EstadoRegistro? Ins02EstadoNavigation { get; set; }
}
