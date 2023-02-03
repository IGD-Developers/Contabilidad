namespace Aplicacion.Models.Contabilidad.TipoComprobantes
{
    public class EditarTipoComprobanteModel
    {
        public int Id { get; set; }
        public int id_categoriacomprobante { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string tco_incremento { get; set; }
        public string editable { get; set; }
        public string anulable { get; set; }
        public string borrable { get; set; }
        public string id_usuario { get; set; }
    }
}