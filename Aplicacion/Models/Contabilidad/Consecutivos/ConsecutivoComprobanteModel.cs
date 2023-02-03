using System;

namespace Aplicacion.Models.Contabilidad.Consecutivos;

public class ConsecutivoComprobanteModel
{
    public int id_tipocomprobante { get; set; }
    public int id_sucursal { get; set; }

    public DateTime fecha {get;set;}
}