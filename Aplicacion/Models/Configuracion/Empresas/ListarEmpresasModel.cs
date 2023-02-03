using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Aplicacion.Models.Configuracion.Empresas
{
    public class ListarEmpresasModel
    {
        public int id { get; set; }
        public string nit { get; set; }
        public string razon_social { get; set; }
        public int? id_tercero_gerente { get; set; }

        public  gerenteEmpresaModel nombregerente { get; set; }
       
       public string terceroEmpresater_razonsocial { get; set; }
       // Lo anterior fue para probar porque en la teoría de Automapper si empieza por el nombre de la propiedad de navegacion debe reconocerlo

        
    }
}