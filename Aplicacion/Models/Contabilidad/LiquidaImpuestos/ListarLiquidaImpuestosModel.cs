using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    public class ListarLiquidaImpuestosModel
    {
        public int id { get; set; }
        public int id_tipoimpuesto { get; set; }
        public int id_comprobante { get; set; }
        public int id_puc { get; set; }
        public int IdTercero { get; set; }
        //public DateTime lim_fecha { get; set; }
        public DateTime lim_fechainicial { get; set; }
        public DateTime lim_fechafinal { get; set; }
        public DateTime? created_at { get; set; }
        public string nombreUsuario { get; set; }
        



        public LiquidaTipoImpuestoModel tipoImpuesto { get; set; }
        public LiquidaImpuestoTerceroModel tercero { get; set; }

        // public CntPucModel puc { get; set; }

        
        public ImpuestoComprobanteModel comprobante { get; set; }
   
        // public CnfUsuarioModel usuario { get; set; }
    }
}