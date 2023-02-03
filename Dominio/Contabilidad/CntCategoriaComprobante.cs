using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntCategoriaComprobante : IDisposable
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CntTipoComprobante> CategoriaTipoComprobantes { get; set; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}