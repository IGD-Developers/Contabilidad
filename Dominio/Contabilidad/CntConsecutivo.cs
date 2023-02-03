using Dominio.Configuracion;

namespace Dominio.Contabilidad
{
    public class CntConsecutivo
    {
        public int id { get; set; }
        public int id_tipocomprobante { get; set; }
        public int id_sucursal { get; set; }
        public string co_ano { get; set; }
        public string co_mes { get; set; }
        public int co_consecutivo { get; set; }

        public CntTipoComprobante TipoComprobante { get; set; }
        public CnfSucursal Sucursal { get; set; }
    }
}