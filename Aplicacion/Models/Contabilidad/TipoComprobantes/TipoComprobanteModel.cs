using Aplicacion.Models.Contabilidad.CategoriaComprobantes;

namespace Aplicacion.Models.Contabilidad.TipoComprobantes
{
    public class TipoComprobanteModel
    {
    
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string editable { get; set; }
        public string anulable { get; set; }



        public CategoriaComprobanteModel categoria { get; set; }
    }
}