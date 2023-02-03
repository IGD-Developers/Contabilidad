using System;
using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Dominio.Contabilidad
{
    public class CntLiquidaImpuesto
    {
        public int id { get; set; }
        public int id_tipoimpuesto { get; set; }
        public int id_comprobante { get; set; }
        public int id_puc { get; set; }
        public int id_tercero { get; set; }
        //public DateTime lim_fecha { get; set; }
        public DateTime lim_fechainicial { get; set; }
        public DateTime lim_fechafinal { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string estado { get; set; }



        public CntTipoImpuesto tipoImpuesto { get; set; }
        public CntTercero tercero { get; set; }

        public CntPuc puc { get; set; }
        public CntComprobante comprobante { get; set; }

      

        




    }
}