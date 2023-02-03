namespace Dominio.Contabilidad;

public class CntConceptoCuenta
{
    public int id { get; set; }
    public int id_exogenaconcepto { get; set; }
    public int id_puc { get; set; }
    public int id_formatocolumna { get; set; }
    public int id_tipooperacion { get; set; }
    public string estado { get; set; }

}