using System;

namespace Aplicacion.Models.Contabilidad.CentroCostos
{
    public class ListarCentroCostosModel
    {
        
        public int Id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}