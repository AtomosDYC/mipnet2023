﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Obsc02ServicioPostcosecha
{
    public int Obsc02llave { get; set; }

    public int? esp08llave { get; set; }

    public int? Temp02llave { get; set; }

    public string? Obsc02nombre { get; set; }

    public string? Obsc02Resumen { get; set; }

    public int? Obsc02activo { get; set; }

    public DateTime? Obsc02Fecha { get; set; }

    public string? Obsc02UrlPdf { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }
}
