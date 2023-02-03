using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntSeccionCiiu
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }

    public ICollection<CntCiiu> seccionCiiuCiiu {get; set;}
}