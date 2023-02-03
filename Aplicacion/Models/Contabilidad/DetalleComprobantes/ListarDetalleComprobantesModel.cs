using Dominio.Contabilidad;

namespace Aplicacion.Models.Contabilidad.DetalleComprobantes
{
    public class ListarDetalleComprobantesModel
    {

        public int id { get; set; }
        public int id_comprobante { get; set; }
        public int id_centrocosto { get; set; }
        public int id_puc { get; set; }
        public int IdTercero { get; set; }
        public double dco_base { get; set; }
        public double dco_tarifa { get; set; }
        public double dco_debito { get; set; }
        public double dco_credito { get; set; }
        public string dco_detalle { get; set; }
        

        
    }

    
}