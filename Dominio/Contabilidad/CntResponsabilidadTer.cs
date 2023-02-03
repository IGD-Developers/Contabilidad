using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntResponsabilidadTer
    {
        public int id { get; set; }
        public int id_tercero {get; set;}
        public int id_responsabilidad {get; set;}
        
        public CntResponsabilidad Responsabilidad {get; set;}
        public CntTercero Tercero {get;set;}

    }
}