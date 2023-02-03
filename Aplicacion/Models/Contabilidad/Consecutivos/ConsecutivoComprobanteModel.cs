using System;

namespace Aplicacion.Models.Contabilidad.Consecutivos;

public class ConsecutivoComprobanteModel
{
    public int IdTipocomprobante { get; set; }
    public int IdSucursal { get; set; }

    public DateTime Fecha {get;set;}
}