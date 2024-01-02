using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class wkf06perfil
{
    public int wkf06llave { get; set; }

    public int? wkf01llave { get; set; }

    public string? wkf06nombre { get; set; }

    public string? wkf06descripcion { get; set; }

    public int? wkf06activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<prf06permisosUsuario> prf06permisosUsuarios { get; } = new List<prf06permisosUsuario>();

    public virtual wkf01Flujo? wkf01llaveNavigation { get; set; }

    public virtual ICollection<wkf07perfilespermiso> wkf07perfilespermisos { get; } = new List<wkf07perfilespermiso>();
}
