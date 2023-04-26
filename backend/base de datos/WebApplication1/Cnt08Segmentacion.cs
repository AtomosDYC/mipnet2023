using System;
using System.Collections.Generic;

namespace WebApplication1;

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

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Cnt01CuentaCliente? Cnt01LlaveNavigation { get; set; }

    public virtual ICollection<Cnt06ComunicacionCliente> Cnt06ComunicacionClientes { get; set; } = new List<Cnt06ComunicacionCliente>();

    public virtual Cnt07TipoSegmentacion? Cnt07LlaveNavigation { get; set; }

    public virtual Cnt08Segmentacion? Cnt08LlavePadreNavigation { get; set; }

    public virtual ICollection<Cnt09ComunicacionSegmentacion> Cnt09ComunicacionSegmentacions { get; set; } = new List<Cnt09ComunicacionSegmentacion>();

    public virtual ICollection<Cnt11ContactoSegmentacion> Cnt11ContactoSegmentacions { get; set; } = new List<Cnt11ContactoSegmentacion>();

    public virtual ICollection<Cnt17Bloqueo> Cnt17Bloqueos { get; set; } = new List<Cnt17Bloqueo>();

    public virtual ICollection<Cnt22EstacionTipoEstacion> Cnt22EstacionTipoEstacions { get; set; } = new List<Cnt22EstacionTipoEstacion>();

    public virtual ICollection<Conteo02Procesado> Conteo02Procesados { get; set; } = new List<Conteo02Procesado>();

    public virtual ICollection<Conteo03Resuman> Conteo03Resumen { get; set; } = new List<Conteo03Resuman>();

    public virtual ICollection<Cnt08Segmentacion> InverseCnt08LlavePadreNavigation { get; set; } = new List<Cnt08Segmentacion>();

    public virtual ICollection<Trp01Trampa> Trp01Trampas { get; set; } = new List<Trp01Trampa>();
}
