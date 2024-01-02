using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Ins02RecuperarClave
{
    public int Ins02llave { get; set; }

    public Guid? userid { get; set; }

    public string? Ins02ClaveTemporal { get; set; }

    public DateTime? Ins02FechaRecupera { get; set; }

    public int? Ins02Estado { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public virtual sist05EstadoRegistro? Ins02EstadoNavigation { get; set; }
}
