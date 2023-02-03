using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntSeccionCiiu
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CntCiiu> SeccionCiiuCiiu { get; set; }
}