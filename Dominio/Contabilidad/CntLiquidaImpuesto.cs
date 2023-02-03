using System;
using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Dominio.Contabilidad
{
    public class CntLiquidaImpuesto
    {
        public int Id { get; set; }
        public int IdTipoimpuesto { get; set; }
        public int IdComprobante { get; set; }
        public int IdPuc { get; set; }
        public int IdTercero { get; set; }
        //public DateTime lim_fecha { get; set; }
        public DateTime LimFechainicial { get; set; }
        public DateTime LimFechafinal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Estado { get; set; }



        public CntTipoImpuesto TipoImpuesto { get; set; }
        public CntTercero Tercero { get; set; }

        public CntPuc Puc { get; set; }
        public CntComprobante Comprobante { get; set; }
    }
}