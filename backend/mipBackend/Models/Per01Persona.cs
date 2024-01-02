using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class per01persona
{
    public int per01llave { get; set; }

    public int per01rut { get; set; }

    public int per03llave { get; set; }

    public int? per08llave { get; set; }

    public int? per02llave { get; set; }

    public string? per01nombrerazon { get; set; }

    public string? per01nombrefantasia { get; set; }

    public string? per01giro { get; set; }

    public string? per01cargo { get; set; }

    public DateTime? per01fechanacimiento { get; set; }

    public int? per01anioingreso { get; set; }

    public int? per01activo { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<cnt01CuentaCliente> cnt01CuentaClientes { get; } = new List<cnt01CuentaCliente>();

    public virtual ICollection<cnt12Empleado> cnt12Empleados { get; } = new List<cnt12Empleado>();

    public virtual per02Genero? per02llaveNavigation { get; set; }

    public virtual per03Tipopersona? per03llaveNavigation { get; set; }

    public virtual per08TipoDocumento? per08llaveNavigation { get; set; }

    public virtual ICollection<per05Comunicacion> per05Comunicacions { get; } = new List<per05Comunicacion>();

    public virtual ICollection<per07personaUsuario> per07personaUsuarios { get; } = new List<per07personaUsuario>();
}
