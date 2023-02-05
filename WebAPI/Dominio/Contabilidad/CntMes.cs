namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntMes
{
    public int Id { get; set; }
    public int MesAno { get; set; }
    public int MesMes { get; set; }
    public bool MesCerrado { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }

    public CnfUsuario Usuario { get; set; }

}