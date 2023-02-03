using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntTipoCiiu
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }

    public ICollection<CntCiiu> tipoCiiuCiiu {get; set;}
}