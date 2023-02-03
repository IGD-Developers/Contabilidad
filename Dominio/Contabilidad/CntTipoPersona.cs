using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntTipoPersona
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<CntTercero> tipoPersonaTercero {get; set;}
    }
}