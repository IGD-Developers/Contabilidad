namespace Aplicacion.Models.Configuracion.Empresas
{
    public class EditarEmpresasModel
    {
        public int Id { get; set; }
        public string nit { get; set; }
        public string razon_social { get; set; }
        public int? id_tercero_gerente { get; set; } 
    }
}