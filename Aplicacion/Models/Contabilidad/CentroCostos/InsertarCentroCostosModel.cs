using System;

namespace Aplicacion.Models.Contabilidad.CentroCostos;

public class InsertarCentroCostosModel
{
    public string codigo { get; set; }
    public string nombre { get; set; }
    public string estado { get; set; }
    public DateTime? created_at { get; set; }
}