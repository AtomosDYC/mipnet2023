﻿using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt08Segmentacion
{
    public int Cnt08Llave { get; set; }

    public int? Cnt01Llave { get; set; }

    public int? Cnt07Llave { get; set; }

    public int? Cnt21Llave { get; set; }

    public string? Cnt08Nombre { get; set; }

    public int? Cnt08LlavePadre { get; set; }

    public int? Sist03Llave { get; set; }

    public int? Cnt08Activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; } = new List<Cnt06ComunicacionCliente>();

    public virtual Cnt07TipoSegmentacion? Cnt07LlaveNavigation { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlavePadreNavigation { get; set; }

    public virtual ICollection<Cnt09ComunicacionSegmentacion> Cnt09ComunicacionSegmentacions { get; } = new List<Cnt09ComunicacionSegmentacion>();

    public virtual ICollection<Cnt11ContactoSegmentacion> Cnt11ContactoSegmentacions { get; } = new List<Cnt11ContactoSegmentacion>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; } = new List<Cnt17Bloqueo>();

    public virtual ICollection<Cnt22EstacionTipoEstacion> Cnt22EstacionTipoEstacions { get; } = new List<Cnt22EstacionTipoEstacion>();

    public virtual ICollection<Conteo02Procesado> Conteo02Procesados { get; } = new List<Conteo02Procesado>();

    public virtual ICollection<Conteo03Resumen> Conteo03Resumen { get; } = new List<Conteo03Resumen>();

    public virtual ICollection<Cnt08Segmentacion> InverseCnt08LlavePadreNavigation { get; } = new List<Cnt08Segmentacion>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; } = new List<Trp01Trampa>();
}
