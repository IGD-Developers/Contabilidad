using Dominio.Contabilidad;

namespace Aplicacion.Models.Contabilidad.DetalleComprobantes
{
    public class InsertarDetalleComprobanteModel
    {
      

        public int id_comprobante { get; set; }
        public int id_centrocosto { get; set; }
        public int id_puc { get; set; }
        public int id_tercero { get; set; }
        public double dco_base { get; set; }
        public double dco_tarifa { get; set; }
        public double dco_debito { get; set; }
        public double dco_credito { get; set; }
        public string dco_detalle { get; set; }
        
    }
}