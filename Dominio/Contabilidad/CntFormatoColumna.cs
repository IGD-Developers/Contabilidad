namespace Dominio.Contabilidad;

public class CntFormatoColumna
{
    public int id { get; set; }
    public int id_exogenaformato { get; set; }
    public string fco_columna { get; set; }
    public string fco_campo { get; set; }
    public string fco_tipo { get; set; }

    public CntExogenaFormato exogenaFormato { get; set; }

}