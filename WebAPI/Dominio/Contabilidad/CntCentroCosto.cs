using System;
using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntCentroCosto
{

    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<CntDetalleComprobante> CentroCostoDetalleComprobantes { get; set; }

}