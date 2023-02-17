using System;
using System.Collections.Generic;

namespace basededatos.Models;

public partial class Sercl01ServiciosCliente
{
    public decimal Sercl01Llave { get; set; }

    public decimal? Cnt19Llave { get; set; }

    public decimal? Serv01Llave { get; set; }

    public decimal? Cnt01Llave { get; set; }

    public decimal? Cnt08Llave { get; set; }

    public decimal? Temp02Llave { get; set; }

    public decimal? Esp03Llave { get; set; }

    public decimal? Esp04Llave { get; set; }

    public decimal? Esp08Llave { get; set; }

    public decimal? Sist04Llave { get; set; }

    public decimal? Sist03Llave { get; set; }

    public decimal? Sercl01TipoGrafico { get; set; }

    public decimal? Conteo03Llave { get; set; }

    public decimal? Sercl01Costo { get; set; }

    public decimal? Sercl01Cantidad { get; set; }

    public virtual ICollection<Sercl02MuestreoFrutum> Sercl02MuestreoFruta { get; } = new List<Sercl02MuestreoFrutum>();
}
