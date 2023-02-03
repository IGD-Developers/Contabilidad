using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntExogenaConcepto
    {
        public int id { get; set; }

        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public ICollection<CntFormatoConcepto> exogenaConceptoFormatoConceptos { get; set; }

    }
}