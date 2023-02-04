using System.Collections.Generic;

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntCiiu
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int IdTipociuu { get; set; }
    public int IdSeccionciiu { get; set; }

    public CntSeccionCiiu CiiuSeccionCiiu { get; set; }
    public CntTipoCiiu CiiuTipoCiiu { get; set; }
    public ICollection<CntTercero> CiiuTerceros { get; set; }
}