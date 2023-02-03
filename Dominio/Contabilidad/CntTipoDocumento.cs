using System.Collections.Generic;
using System;

namespace Dominio.Contabilidad;

public class CntTipoDocumento
{
    public int id { get; set; }
    public int codigo { get; set; }
    public string nombre { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? update_at { get; set; }

    public ICollection<CntTercero> documentoTerceros {get; set;}

    
    
}