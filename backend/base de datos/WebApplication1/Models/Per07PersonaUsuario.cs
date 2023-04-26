using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Per07PersonaUsuario
{
    public int Per07Llave { get; set; }

    public int? Per01Llave { get; set; }

    public Guid? Secu02Llave { get; set; }

    public int? Per07Activo { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public DateTime? Fechaeliminacion { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? ApproveBy { get; set; }

    public Guid? DeleteBy { get; set; }

    public virtual Per01Persona? Per01LlaveNavigation { get; set; }
}
