using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Departamentos;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Municipios;

public class MunicipioModel
{
    public int Id { get; set; }
    public int IdDepartamento { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public DepartamentosModel DepartamentosModel { get; set; }
}