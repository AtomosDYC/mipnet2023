using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Esp08TipoBase
{
    public int esp08llave { get; set; }

    public string? esp08nombre { get; set; }

    public string? esp08descripcion { get; set; }

    public int? esp08activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Esp03EspecieBase> Esp03EspecieBases { get; } = new List<Esp03EspecieBase>();

    public virtual ICollection<Obsc01ObservacionCampo> Obsc01ObservacionCampos { get; } = new List<Obsc01ObservacionCampo>();
}
