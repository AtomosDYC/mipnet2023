using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class Cnt20LicenciaServicio
{
    public int Cnt19Llave { get; set; }

    public int Serv01Llave { get; set; }

    public int? Cnt20Habilitaservicio { get; set; }

    public int? Cnt20Valor { get; set; }

    public virtual Cnt19LicenciaCliente Cnt19LlaveNavigation { get; set; } = null!;
}
