using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntMunicipio
    {
        public int id { get; set; }
        public int id_departamento {get;set;}
        public string codigo { get; set; }
        public string nombre { get; set; }

        public CntDepartamento departamento {get;set;}
        public ICollection<CntTercero> municipioTerceros {get; set;}

    }
}