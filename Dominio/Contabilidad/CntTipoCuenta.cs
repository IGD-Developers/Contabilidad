using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntTipoCuenta
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }


        public ICollection<CntPuc> TipoCuentaPucs { get; set; }
    }
}