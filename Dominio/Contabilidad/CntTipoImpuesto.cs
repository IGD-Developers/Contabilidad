using System.Collections.Generic;

namespace Dominio.Contabilidad
{
    public class CntTipoImpuesto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }


        public ICollection<CntCuentaImpuesto> CntTipoImpuestoCntCuentaImpuestos { get; set; }
        public ICollection<CntEntidad> TipoImpuestoEntidades { get; set; }
        public ICollection<CntLiquidaImpuesto> TipoImpuestoLiquidaImpuestos { get; set; }
        public ICollection<CntPuc> TipoImpuestoPuc { get; set; }
    }
}