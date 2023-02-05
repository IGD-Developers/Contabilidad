namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntUvt
{
    public int Id { get; set; }
    public int UvtAno { get; set; }
    public double UvtValor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}