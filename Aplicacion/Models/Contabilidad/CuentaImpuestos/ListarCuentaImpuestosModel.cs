namespace Aplicacion.Models.Contabilidad.CuentaImpuestos
{
    public class ListarCuentaImpuestosModel
    {
        public int id { get; set; }
        public int id_puc { get; set; }
        public int id_tipoimpuesto { get; set; }

        public string tipoimpuestocodigo { get; set; }
        public string tipoimpuestonombre { get; set; }
        
        public string puccodigo { get; set; }
        public string pucnombre { get; set; }




           
    }
}