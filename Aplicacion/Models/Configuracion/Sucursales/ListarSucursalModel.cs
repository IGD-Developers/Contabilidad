using Aplicacion.Models.Configuracion.Empresas;

namespace Aplicacion.Models.Configuracion.Sucursales
{
    public class ListarSucursalModel
    {
        
         public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int id_empresa { get; set; }

        public EmpresasModel empresa { get; set; }
    }
}