using System;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class FiltroLiquidaImpuestosModel
{
    public int IdSucursal { get; set; }
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
}