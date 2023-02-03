using System.Collections.Generic;
using Dominio.Contabilidad;

namespace Dominio.Configuracion
{
    public class CnfSucursal
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int id_empresa { get; set; }

        public CnfEmpresa empresa { get; set; }
        public ICollection<CntComprobante> sucursalComprobantes { get; set; }
        public ICollection<CntConsecutivo> sucursalConsecutivo { get; set; }
    }
}