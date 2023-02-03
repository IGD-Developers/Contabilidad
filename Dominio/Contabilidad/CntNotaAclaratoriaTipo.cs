using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntNotaAclaratoriaTipo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }

        public ICollection<CntNotaAclaratoria> notaAclaratoriaTipoNotaAclaratorias { get; set; }
    }
}