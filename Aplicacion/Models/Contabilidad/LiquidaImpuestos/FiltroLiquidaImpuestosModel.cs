using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    public class FiltroLiquidaImpuestosModel
    {
        
        public int id_sucursal { get; set; }
        public DateTime fechainicial { get; set; }
        public DateTime fechafinal { get; set; }
    }
}