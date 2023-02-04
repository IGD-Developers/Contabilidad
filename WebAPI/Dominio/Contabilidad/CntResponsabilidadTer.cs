using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntResponsabilidadTer
{
    public int Id { get; set; }
    public int IdTercero { get; set; }
    public int IdResponsabilidad { get; set; }

    public CntResponsabilidad Responsabilidad { get; set; }
    public CntTercero Tercero { get; set; }
}