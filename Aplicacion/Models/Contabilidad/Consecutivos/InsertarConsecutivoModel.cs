namespace Aplicacion.Models.Contabilidad.Consecutivos
{
    public class InsertarConsecutivoModel
    {
        //public int Id { get; set; }
        public int IdTipocomprobante { get; set; }
        public int IdSucursal { get; set; }
        public string CoAno { get; set; }
        public string CoMes { get; set; }
        public int CoConsecutivo { get; set; }
        
    }
}