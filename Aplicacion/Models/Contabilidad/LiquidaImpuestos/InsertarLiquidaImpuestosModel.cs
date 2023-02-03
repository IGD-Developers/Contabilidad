using System;
using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class InsertarLiquidaImpuestosModel
{
   public int IdTipoimpuesto { get; set; }
    public int IdSucursal { get; set; }
    public int IdEntidad  { get; set; }
    public string CcoDocumento { get; set; }
    //public DateTime CcoFecha { get; set; }
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
    //public string IdUsuario { get; set; } 

    public InsertarComprobantesModel Comprobante { get; set; } 

    //public ICollection<InsertarDetalleComprobanteModel> ComprobanteDetalleComprobantes { get; set; }
  

}