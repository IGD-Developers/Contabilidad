namespace Dominio.Contabilidad;

public class CntEntidad
{
    public int Id { get; set; }
    public int IdTercero { get; set; }
    public int IdTipoimpuesto { get; set; }

    public CntTercero Tercero { get; set; }
    public CntTipoImpuesto TipoImpuesto { get; set; }


}