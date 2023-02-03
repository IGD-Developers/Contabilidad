using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    public class FiltroGeneraImpuestosModel
    {    
        public int IdTipoimpuesto { get; set; }
        public int IdSucursal { get; set; }
        public int IdEntidad  { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }        
    }
}