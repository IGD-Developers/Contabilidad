using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntGenero
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }

        public ICollection<CntTercero> generoTerceros {get; set;}
    }
}