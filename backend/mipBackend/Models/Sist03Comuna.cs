using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class sist03Comuna
{
    public int sist03llave { get; set; }

    public int? sist04llave { get; set; }

    public string? sist03nombre { get; set; }

    public string? sist03descripcion { get; set; }

    public int? sist03capital { get; set; }

    public int? sist03activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt06ComunicacionCliente> cnt06ComunicacionClientes { get; } = new List<cnt06ComunicacionCliente>();

    public virtual ICollection<Conteo04ResumenSag> Conteo04ResumenSags { get; } = new List<Conteo04ResumenSag>();

    public virtual sist04Region? sist04llaveNavigation { get; set; }

    public virtual ICollection<sist02Zona> sist02llaves { get; } = new List<sist02Zona>();
}
