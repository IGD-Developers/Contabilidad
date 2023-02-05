namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntTipoCiiu
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public ICollection<CntCiiu> TipoCiiuCiiu { get; set; }
}