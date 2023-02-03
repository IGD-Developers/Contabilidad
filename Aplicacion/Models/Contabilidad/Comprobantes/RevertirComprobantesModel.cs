using System;
using Aplicacion.Models.Configuracion.Sucursales;
using Aplicacion.Models.Configuracion.Usuarios;
using Aplicacion.Models.Contabilidad.TipoComprobantes;

namespace Aplicacion.Models.Contabilidad.Comprobantes
{
    public class RevertirComprobantesModel
    {
        public int Id { get; set; }
         public int id_sucursal { get; set; }
        public int id_tipocomprobante { get; set; }
        public int id_modulo { get; set; }
        public int id_tercero { get; set; }
        public int? id_reversion { get; set; }
        public string cco_ano { get; set; }
        public string cco_mes { get; set; }
        public int cco_consecutivo { get; set; }
        public DateTime cco_fecha { get; set; }
        public string cco_documento { get; set; }
        public string cco_detalle { get; set; }
        public string id_usuario { get; set; }
      
        
    }
}