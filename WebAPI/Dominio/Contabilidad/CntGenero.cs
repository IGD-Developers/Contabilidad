using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntGenero
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CntTercero> GeneroTerceros { get; set; }
}