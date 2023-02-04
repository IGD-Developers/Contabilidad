namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoComprobantes;

public class EditarTipoComprobanteModel
{
    public int Id { get; set; }
    public int IdCategoriacomprobante { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string TcoIncremento { get; set; }
    public string Editable { get; set; }
    public string Anulable { get; set; }
    public string Borrable { get; set; }
    public string IdUsuario { get; set; }
}