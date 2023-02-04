using System.Collections.Generic;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;

public class ListarCategoriaComprobantesModel
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CategoriaTipoComprobantesModel> categoriaTipoComprobantes { get; set; }

}