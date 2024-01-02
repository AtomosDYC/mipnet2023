using System;
using System.Collections.Generic;

namespace mipBackend.Models;

public partial class cnt20LicenciaServicio
{
    public int cnt19llave { get; set; }

    public int Serv01llave { get; set; }

    public int? cnt20Habilitaservicio { get; set; }

    public int? cnt20Valor { get; set; }

    public virtual cnt19LicenciaCliente cnt19llaveNavigation { get; set; } = null!;
}
