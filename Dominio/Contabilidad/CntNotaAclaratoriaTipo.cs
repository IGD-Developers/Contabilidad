using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntNotaAclaratoriaTipo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<CntNotaAclaratoria> NotaAclaratoriaTipoNotaAclaratorias { get; set; }
    }
}