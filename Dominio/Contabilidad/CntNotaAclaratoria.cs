using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntNotaAclaratoria
    {

        public int id { get; set; }
        public int nac_consecutivo { get; set; }
        public DateTime nac_fecha { get; set; }
        public int? id_puc { get; set; }
        public int id_notaaclaratoriatipo { get; set; }
        public string nac_titulo { get; set; }
        public string nac_detalle { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }
        public string estado {get; set;} 
      


        public CntNotaAclaratoriaTipo notaAclaratoriaTipo { get; set; }
        public CntPuc cntPuct { get; set; }
        /* public ICollection<CntNotaAclaratoriaCuenta> notaAclaratoriaNotaAclaratoriaCuentas { get; set; } */






    }
}