using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntTipoCuenta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<CntPuc> TipoCuentaPucs { get; set; }
    }
}