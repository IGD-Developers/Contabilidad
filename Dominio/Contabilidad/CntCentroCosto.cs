using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntCentroCosto
{

    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public string estado { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }

    public ICollection<CntDetalleComprobante> centroCostoDetalleComprobantes { get; set; }

}