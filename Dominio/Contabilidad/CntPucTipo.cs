using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntPucTipo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public ICollection<CntPuc> cntPucTipoPucs { get; set; }

    }
}