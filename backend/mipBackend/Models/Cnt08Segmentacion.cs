using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt08Segmentacion
{
    public int cnt08llave { get; set; }

    public int? cnt01llave { get; set; }

    public int? cnt07llave { get; set; }

    public int? cnt21llave { get; set; }

    public string? cnt08nombre { get; set; }

    public int? cnt08llavePadre { get; set; }

    public int? sist03llave { get; set; }

    public int? cnt08activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual cnt01CuentaCliente? cnt01llaveNavigation { get; set; }

    public virtual ICollection<cnt06ComunicacionCliente> cnt06ComunicacionClientes { get; } = new List<cnt06ComunicacionCliente>();

    public virtual cnt07TipoSegmentacion? cnt07llaveNavigation { get; set; }

    public virtual cnt08Segmentacion? cnt08llavePadreNavigation { get; set; }

    public virtual ICollection<cnt09ComunicacionSegmentacion> cnt09ComunicacionSegmentacions { get; } = new List<cnt09ComunicacionSegmentacion>();

    public virtual ICollection<cnt11ContactoSegmentacion> cnt11ContactoSegmentacions { get; } = new List<cnt11ContactoSegmentacion>();

    public virtual ICollection<cnt17Bloqueo> cnt17Bloqueos { get; } = new List<cnt17Bloqueo>();

    public virtual ICollection<cnt22EstacionTipoEstacion> cnt22EstacionTipoEstacions { get; } = new List<cnt22EstacionTipoEstacion>();

    public virtual ICollection<Conteo02Procesado> Conteo02Procesados { get; } = new List<Conteo02Procesado>();

    public virtual ICollection<Conteo03Resumen> Conteo03Resumen { get; } = new List<Conteo03Resumen>();

    public virtual ICollection<cnt08Segmentacion> Inversecnt08llavePadreNavigation { get; } = new List<cnt08Segmentacion>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; } = new List<Trp01Trampa>();
}
