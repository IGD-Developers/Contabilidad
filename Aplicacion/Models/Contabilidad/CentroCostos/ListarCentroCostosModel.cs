using System;

namespace Aplicacion.Models.Contabilidad.CentroCostos
{
    public class ListarCentroCostosModel
    { 
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}