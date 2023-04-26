using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Log03MensajeBitacora
{
    public int Log03Llave { get; set; }

    public Guid? Log02Llave { get; set; }

    public string? Log03AccesoRapido { get; set; }

    public string? Log03Descripcion { get; set; }

    public string? Log03Mensaje { get; set; }

    public int? Log03Activo { get; set; }

    public string? Log03Info { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Log01Bitacora> Log01Bitacoras { get; set; } = new List<Log01Bitacora>();

    public virtual Log02TipoBitacora? Log02LlaveNavigation { get; set; }
}
