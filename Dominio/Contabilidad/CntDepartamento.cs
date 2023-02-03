using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntDepartamento
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public ICollection<CntMunicipio> departamentoMunicipios {get; set;}
}