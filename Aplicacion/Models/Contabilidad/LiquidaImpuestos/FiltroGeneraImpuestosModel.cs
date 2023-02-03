using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class FiltroGeneraImpuestosModel
{
    
    public int id_tipoimpuesto { get; set; }
    public int id_sucursal { get; set; }
    public int id_entidad  { get; set; }

    public DateTime fechainicial { get; set; }
    public DateTime fechafinal { get; set; }
    
}