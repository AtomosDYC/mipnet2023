using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf01Flujo
{
    public int wkf01llave { get; set; }

    public string? wkf01nombre { get; set; }

    public string? wkf01descripcion { get; set; }

    public int? wkf01llavepadre { get; set; }

    public int? wkf03llave { get; set; }

    public int? wkf01esinicio { get; set; }

    public int? wkf01orden { get; set; }

    public int? wkf01prioridad { get; set; }

    public int wkf01activo { get; set; }

    public string? wkf01directorio { get; set; }

    public string? wkf01url { get; set; }

    public string? wkf01iconourl { get; set; }

    public int? wkf01visiblemenu { get; set; }

    public string? wkf01imagengrande { get; set; }

    public string? wkf01imagenpequena { get; set; }

    public string wkf01estadoregistro { get; set; } = null!;

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual wkf03Nivel? wkf03llaveNavigation { get; set; }

    public virtual ICollection<wkf06perfil> wkf06perfiles { get; } = new List<wkf06perfil>();


    public virtual ICollection<wkf09Parametro> wkf09Parametros { get; } = new List<wkf09Parametro>();
}
