using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntCategoriaComprobante:IDisposable
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }

    public ICollection<CntTipoComprobante> categoriaTipoComprobantes { get; set; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}