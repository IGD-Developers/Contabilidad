using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntCiiu
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int id_tipociuu {get; set;}
        public int id_seccionciiu {get; set;}

        public CntSeccionCiiu ciiuSeccionCiiu {get; set;}
        public CntTipoCiiu ciiuTipoCiiu {get; set;}
        public ICollection<CntTercero> ciiuTerceros {get; set;}


    }
}