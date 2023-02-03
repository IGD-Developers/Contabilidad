using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class ConsultaGenerarLiquidacionImpuesto
{
    public int IdTipoimpuesto { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    public DateTime LimFecha { get; set; }
    public DateTime LimFechainicial { get; set; }
    public DateTime LimFechafinal { get; set; }
    public DateTime? CreatedAt { get; set; }
    
}