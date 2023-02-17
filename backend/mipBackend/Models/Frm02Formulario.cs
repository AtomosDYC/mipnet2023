using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Frm02Formulario
{
    public int Frm02Llave { get; set; }

    public int? Frm01Llave { get; set; }

    public string? Frm02Nombre { get; set; }

    public string? Frm02Empresa { get; set; }

    public string? Frm02Ciudad { get; set; }

    public string? Frm02Direccion { get; set; }

    public string? Frm02Mail { get; set; }

    public string? Frm02Telefono { get; set; }

    public string? Frm02Celular { get; set; }

    public string? Frm02Mensaje { get; set; }

    public int? Frm02Activo { get; set; }

    public int? Frm02EstadoRespuesta { get; set; }

    public int? Eml01Llave { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual Eml01BitacoraEmailUsuario? Eml01LlaveNavigation { get; set; }

    public virtual Frm01TipoFormulario? Frm01LlaveNavigation { get; set; }
}
