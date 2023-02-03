using System.Collections.Generic;
using System;

namespace Dominio.Contabilidad;

public class CntTipoDocumento
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    public ICollection<CntTercero> DocumentoTerceros { get; set; }
}