namespace Dominio.Contabilidad;

public class CntFormatoConcepto
{
    public int Id { get; set; }
    public int IdExogenaformato { get; set; }
    public int IdExogenaconcepto { get; set; }

    public CntExogenaFormato ExogenaFormato { get; set; }
    public CntExogenaConcepto ExogenaConcepto { get; set; }

}