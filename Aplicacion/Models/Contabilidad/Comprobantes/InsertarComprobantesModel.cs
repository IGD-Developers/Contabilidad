using MediatR;
using System;
using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Aplicacion.Contabilidad.Consecutivos;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.Consecutivos;

namespace Aplicacion.Models.Contabilidad.Comprobantes
{
    public class InsertarComprobantesModel
    {

        public int id_sucursal { get; set; }
        public int id_tipocomprobante { get; set; }
        public int id_modulo { get; set; }
        public int IdTercero { get; set; }
        public int? id_reversion { get; set; }
        public string cco_ano { get; set; }
        public string cco_mes { get; set; }
        public int cco_consecutivo { get; set; }
        public DateTime cco_fecha { get; set; }
        public string cco_documento { get; set; }
        public string cco_detalle { get; set; }
        public string id_usuario { get; set; }
        public double tdebito { get; set; }
        public double tcredito { get; set; }
        

        public ICollection<InsertarDetalleComprobanteModel> comprobanteDetalleComprobantes { get; set; }
       
      
    }
}