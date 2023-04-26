using System;
using System.Collections.Generic;

namespace mipBackend.Models;
public partial class Per08TipoDocumento
{

    public int per08llave { get; set; }

    public string? per08nombre { get; set; }

    public string? per08descripcion { get; set; }

    public int? per08activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Per01Persona> Per01Personas { get; } = new List<Per01Persona>();

}

