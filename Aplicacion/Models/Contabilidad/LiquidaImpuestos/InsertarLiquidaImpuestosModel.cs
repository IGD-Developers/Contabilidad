using System;
using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{
    public class InsertarLiquidaImpuestosModel
    {
       public int id_tipoimpuesto { get; set; }
        public int id_sucursal { get; set; }
        public int id_entidad  { get; set; }
        public string cco_documento { get; set; }
        //public DateTime cco_fecha { get; set; }
        public DateTime fechainicial { get; set; }
        public DateTime fechafinal { get; set; }
        //public string id_usuario { get; set; } 

        public InsertarComprobantesModel comprobante { get; set; } 

        //public ICollection<InsertarDetalleComprobanteModel> comprobanteDetalleComprobantes { get; set; }
      

    }
}