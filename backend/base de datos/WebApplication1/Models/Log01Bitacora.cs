using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Log01Bitacora
{
    public int Log01Llave { get; set; }

    public int? Log03Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public string? Log01Contenido { get; set; }

    public int? Log01Objeto { get; set; }

    public string? Log01Clase { get; set; }

    public byte[]? Log01ElementoSerializado { get; set; }

    public string? Log01Info { get; set; }

    public int? Log01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Log03MensajeBitacora? Log03LlaveNavigation { get; set; }
}
