using Aplicacion.Models.Contabilidad.Departamentos;

namespace Aplicacion.Models.Contabilidad.Municipios
{
    public class MunicipioModel
    {
        public int id { get; set; }
        public int id_departamento {get;set;}
        public string codigo { get; set; }
        public string nombre { get; set; }

        public DepartamentosModel departamentosModel {get; set;}

        
    }
}