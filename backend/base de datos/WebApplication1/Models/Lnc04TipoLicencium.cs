using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lnc04TipoLicencium
{
    public int Lnc04Llave { get; set; }

    public string? Lnc04Nombre { get; set; }

    public string? Lnc04Descripcion { get; set; }

    public int? Lnc04Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }
}
