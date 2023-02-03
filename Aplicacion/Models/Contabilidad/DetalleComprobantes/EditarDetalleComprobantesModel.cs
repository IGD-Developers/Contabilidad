using Dominio.Contabilidad;

namespace Aplicacion.Models.Contabilidad.DetalleComprobantes
{
    public class EditarDetalleComprobantesModel
    {
        public int IdComprobante { get; set; }
        public int IdCentrocosto { get; set; }
        public int IdPuc { get; set; }
        public int IdTercero { get; set; }
        public double DcoBase { get; set; }
        public double DcoTarifa { get; set; }
        public double DcoDebito { get; set; }
        public double DcoCredito { get; set; }
        public string DcoDetalle { get; set; }      
    }
}