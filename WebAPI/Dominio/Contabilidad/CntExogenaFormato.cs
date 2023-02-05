namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntExogenaFormato

{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CntFormatoColumna> ExogenaFormatoFormatoColumnas { get; set; }

    public ICollection<CntFormatoConcepto> ExogenaFormatoFormatoConceptos { get; set; }
}