using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntResponsabilidad
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public ICollection<CntResponsabilidadTer> ReponsabilidadResponsabilidadTerceros { get; set; }
}