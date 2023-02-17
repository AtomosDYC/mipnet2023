using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Eml02MailBase
{
    public int Eml02Llave { get; set; }

    public int? Eml03Llave { get; set; }

    public string? Eml02CodigoLlamado { get; set; }

    public string? Eml02Descripcion { get; set; }

    public string? Eml02Asunto { get; set; }

    public string? Eml02ContenidoHtml { get; set; }

    public string? Eml02ContenidoText { get; set; }

    public int? Eml02Activo { get; set; }

    public int? Eml04Llave { get; set; }

    public DateTime? fechaeliminacion { get; set; }

    public DateTime? fechaactualizacion { get; set; }

    public DateTime? fechaactivacion { get; set; }

    public Guid? createby { get; set; }

    public Guid? approveby { get; set; }

    public Guid? deleteby { get; set; }

    public virtual ICollection<Eml01BitacoraEmailUsuario> Eml01BitacoraEmailUsuarios { get; } = new List<Eml01BitacoraEmailUsuario>();

    public virtual Eml03TipoMailAccion? Eml03LlaveNavigation { get; set; }

    public virtual Eml04ImportanciaMail? Eml04LlaveNavigation { get; set; }
}
