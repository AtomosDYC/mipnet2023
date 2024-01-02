using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class sist02Zona
{
    public int sist02llave { get; set; }

    public string? sist02nombre { get; set; }

    public string? sist02descripcion { get; set; }

    public string? sist02estadoregistro { get; set; }

    public int? sist02activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<sist03Comuna> sist03llaves { get; } = new List<sist03Comuna>();
}
