using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntResponsabilidad
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public ICollection<CntResponsabilidadTer> reponsabilidadResponsabilidadTerceros {get; set;}
    }
}