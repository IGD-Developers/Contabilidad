namespace Aplicacion.Models.Contabilidad.Consecutivos;

public class InsertarConsecutivoModel
{
    //public int id { get; set; }
    public int id_tipocomprobante { get; set; }
    public int id_sucursal { get; set; }
    public string co_ano { get; set; }
    public string co_mes { get; set; }
    public int co_consecutivo { get; set; }
    
}