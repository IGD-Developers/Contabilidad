using System;
using System.Collections.Generic;

namespace Dominio.Contabilidad;

public class CntPucTipo
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<CntPuc> CntPucTipoPucs { get; set; }

}