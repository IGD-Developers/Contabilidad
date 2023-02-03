using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntTipoImpuesto
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }


    public ICollection<CntCuentaImpuesto> cntTipoImpuestoCntCuentaImpuestos { get; set; }
    public ICollection<CntEntidad> tipoImpuestoEntidades { get; set; }
    public ICollection<CntLiquidaImpuesto> tipoImpuestoLiquidaImpuestos { get; set; }
    public ICollection<CntPuc> tipoImpuestoPuc { get; set; }
}