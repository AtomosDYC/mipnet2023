using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Log01Bitacora
{
    public int Log01llave { get; set; }

    public int? Log03llave { get; set; }

    public Guid? userid { get; set; }

    public string? Log01Contenido { get; set; }

    public int? Log01Objeto { get; set; }

    public string? Log01Clase { get; set; }

    public byte[]? Log01ElementoSerializado { get; set; }

    public string? Log01Info { get; set; }

    public int? Log01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Log03MensajeBitacora? Log03llaveNavigation { get; set; }
}
