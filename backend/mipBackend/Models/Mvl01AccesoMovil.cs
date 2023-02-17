using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Mvl01AccesoMovil
{
    public string Mvl01Llave { get; set; } = null!;

    public Guid? Mvl01IdUsuario { get; set; }

    public string? Mvl01NumeroMovil { get; set; }

    public string? Mvl01SistemaAndroid { get; set; }

    public string? Mvl01VersionAndroid { get; set; }

    public string? Mvl01VersionAplicacion { get; set; }

    public string? Mvl01VersionDescarga { get; set; }

    public bool? Mvl01EstaBloqueado { get; set; }

    public string? Mvl01MensajeMovil { get; set; }

    public DateTime? Mvl01FechaMensaje { get; set; }

    public DateTime? Mvl01FechaRegistro { get; set; }

    public DateTime? Mvl01FechaUltimoAcceso { get; set; }

    public DateTime? Mvl01FechaUltimaActividad { get; set; }

    public DateTime? Mvl01FechaUltimaSincro { get; set; }

    public int? Mvl01TamanoBasedatosCliente { get; set; }

    public int? Mvl01UbicacionActividadX { get; set; }

    public int? Mvl01UbicacionActividadY { get; set; }

    public bool? Mvl01EditaFechaMonitoreo { get; set; }

    public int? Mvl01DiasUmbralEdicion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }
}
