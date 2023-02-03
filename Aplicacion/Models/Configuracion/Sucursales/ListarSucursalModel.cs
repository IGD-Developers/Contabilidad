using Aplicacion.Models.Configuracion.Empresas;

namespace Aplicacion.Models.Configuracion.Sucursales
{
    public class ListarSucursalModel
    {  
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdEmpresa { get; set; }

        public EmpresasModel Empresa { get; set; }
    }
}