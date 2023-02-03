using System.Collections.Generic;

namespace Aplicacion.Models.Contabilidad.CategoriaComprobantes
{
    public class ListarCategoriaComprobantesModel
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }

        public ICollection<CategoriaTipoComprobantesModel> categoriaTipoComprobantes { get; set; }

    }
}