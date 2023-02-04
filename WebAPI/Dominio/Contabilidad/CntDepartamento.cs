using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntDepartamento
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public ICollection<CntMunicipio> DepartamentoMunicipios { get; set; }
}