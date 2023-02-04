using System.Collections.Generic;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Ciius;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoCiius;

public class TipoCiiusModel
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
}