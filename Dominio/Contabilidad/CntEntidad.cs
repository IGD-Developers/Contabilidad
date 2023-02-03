namespace Dominio.Contabilidad;

public class CntEntidad
{
    public int id { get; set; }
    public int id_tercero { get; set; }
    public int id_tipoimpuesto { get; set; }

    public CntTercero tercero { get; set; }
    public CntTipoImpuesto tipoImpuesto { get; set; }


}