namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;

public class ListarNotaAclaratoriaModel
{
    public int Id { get; set; }
    public int NacConsecutivo { get; set; }
    public DateTime NacFecha { get; set; }
    public int? IdPuc { get; set; }
    public int IdNotaaclaratoriatipo { get; set; }
    public string NacTitulo { get; set; }
    public string NacDetalle { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }

    public NotaAclaratoriaTipoModel NotaAclaratoriaTipoModel { get; set; }
    public ListarPucNotaAclaratoriaModel PucModel { get; set; }
}