namespace Dominio.Contabilidad;

public class CntConceptoCuenta
{
    public int Id { get; set; }
    public int IdExogenaconcepto { get; set; }
    public int IdPuc { get; set; }
    public int IdFormatocolumna { get; set; }
    public int IdTipooperacion { get; set; }
    public string Estado { get; set; }

}