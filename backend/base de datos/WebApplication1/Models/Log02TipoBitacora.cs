using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Log02TipoBitacora
{
    public Guid Log02Llave { get; set; }

    public string? Log02Nombre { get; set; }

    public string? Log02Descripcion { get; set; }

    public int? Log02EsSistema { get; set; }

    public int? Log02EsRazor { get; set; }

    public string? Log02Info { get; set; }

    public int? Log02Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Log03MensajeBitacora> Log03MensajeBitacoras { get; set; } = new List<Log03MensajeBitacora>();
}
