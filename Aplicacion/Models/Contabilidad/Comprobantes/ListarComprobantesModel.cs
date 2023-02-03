using System;
using System.Collections.Generic;
using Aplicacion.Models.Configuracion.Sucursales;
using Aplicacion.Models.Configuracion.Usuarios;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Aplicacion.Models.Contabilidad.TipoComprobantes;

namespace Aplicacion.Models.Contabilidad.Comprobantes
{
    public class ListarComprobantesModel
    {
        public int id { get; set; }
        public int id_sucursal { get; set; }
        public int id_tipocomprobante { get; set; }
        public int id_modulo { get; set; }
        public int id_tercero { get; set; }
        public int? id_reversion { get; set; }
        public string cco_ano { get; set; }
        public string cco_mes { get; set; }
        public int cco_consecutivo { get; set; }
        public DateTime? cco_fecha { get; set; }
        public string cco_documento { get; set; }
        public string cco_detalle { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }
        public double tdebito { get; set; }
        public double tcredito { get; set; }
        public string estado { get; set; }
        //public string nombregerente { get; set; }

        public  TipoComprobanteModel tipoComprobante{ get; set; }
        public SucursalModel sucursal{get;set;}
        public UsuarioModel usuario{get;set;}
        
        public ICollection<ListarDetalleComprobantesModel> comprobanteDetalleComprobantes { get; set; }




    }
}