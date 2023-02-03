using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntExogenaFormato

{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }

    public ICollection<CntFormatoColumna> exogenaFormatoFormatoColumnas { get; set; }

    public ICollection<CntFormatoConcepto> exogenaFormatoFormatoConceptos { get; set; }
}