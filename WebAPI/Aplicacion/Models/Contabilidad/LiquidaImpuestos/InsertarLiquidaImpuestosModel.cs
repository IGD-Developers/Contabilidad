using System;
using System.Collections.Generic;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class InsertarLiquidaImpuestosModel
{
    public int IdTipoimpuesto { get; set; }
    public int IdSucursal { get; set; }
    public int IdEntidad { get; set; }
    public string CcoDocumento { get; set; }
    //public DateTime CcoFecha { get; set; }
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
    //public string IdUsuario { get; set; } 

    public InsertarComprobantesModel Comprobante { get; set; }

    //public ICollection<InsertarDetalleComprobanteModel> ComprobanteDetalleComprobantes { get; set; }


}