namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CentroCostos;

public class InsertarCentroCostosModel
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public DateTime? CreatedAt { get; set; }
}