namespace Dominio.Contabilidad;

public class CntCuentaImpuesto
{
    public int id { get; set; }
    public int id_puc { get; set; }
    public int id_tipoimpuesto { get; set; }


    public CntPuc puc { get; set; }
    public CntTipoImpuesto tipoImpuesto { get; set; }
}