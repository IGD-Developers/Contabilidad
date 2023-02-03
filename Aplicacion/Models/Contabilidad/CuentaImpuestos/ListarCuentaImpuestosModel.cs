namespace Aplicacion.Models.Contabilidad.CuentaImpuestos
{
    public class ListarCuentaImpuestosModel
    {
        public int Id { get; set; }
        public int IdPuc { get; set; }
        public int IdTipoimpuesto { get; set; }

        public string TipoImpuestoCodigo { get; set; }
        public string TipoImpuestoNombre { get; set; }
        
        public string PucCodigo { get; set; }
        public string PucNombre { get; set; }      
    }
}