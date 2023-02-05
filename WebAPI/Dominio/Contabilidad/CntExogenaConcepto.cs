namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntExogenaConcepto
{
    public int Id { get; set; }

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public ICollection<CntFormatoConcepto> ExogenaConceptoFormatoConceptos { get; set; }

}