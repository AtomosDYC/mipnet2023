using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Frm01TipoFormulario
{
    public int Frm01Llave { get; set; }

    public string? Frm01Nombre { get; set; }

    public int? Frm01Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual ICollection<Frm02Formulario> Frm02Formularios { get; set; } = new List<Frm02Formulario>();
}
