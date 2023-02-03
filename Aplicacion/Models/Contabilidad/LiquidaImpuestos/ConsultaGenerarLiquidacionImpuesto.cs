using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    public class ConsultaGenerarLiquidacionImpuesto
    {
        public int id_tipoimpuesto { get; set; }
        public int id_puc { get; set; }
        public int IdTercero { get; set; }
        public DateTime lim_fecha { get; set; }
        public DateTime lim_fechainicial { get; set; }
        public DateTime lim_fechafinal { get; set; }
        public DateTime? created_at { get; set; }
        
    }
}