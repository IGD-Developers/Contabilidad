using Aplicacion.Models.Contabilidad.Departamentos;

namespace Aplicacion.Models.Contabilidad.Municipios;

public class MunicipioModel
{
    public int Id { get; set; }
    public int IdDepartamento {get;set;}
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public DepartamentosModel DepartamentosModel {get; set;}        
}