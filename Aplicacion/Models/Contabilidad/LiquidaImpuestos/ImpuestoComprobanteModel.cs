using System.Collections.Generic;
using Dominio.Contabilidad;
namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    /// <summary>ImpuestoComprobanteModel:<para> </para> 
     ///Modelo para obtener los datos del comprobante y su total debito y credito
     ///que se genera al liquidar Impuesto. <para> </para>
     ///Data desde CntComprobantes. Incluye la relacion  a tipoComprobante y
     ///la Collection detalleComprobante</summary>
    public class ImpuestoComprobanteModel
    {
     public int id_sucursal { get; set; }
        public int id_tipocomprobante { get; set; }  
        public string cco_ano { get; set; }
        public string cco_mes { get; set; }
        public int cco_consecutivo { get; set; } 
        public double tdebito { get; set; }
        public double tcredito { get; set; }
        //public string id_usuario { get; set; }
        
        public ICollection<ImpuestoDetalleComprobantesModel> comprobanteDetalleComprobantes { get; set; }
        public ImpuestoTipoComprobanteModel tipoComprobante { get; set; }

    }
}