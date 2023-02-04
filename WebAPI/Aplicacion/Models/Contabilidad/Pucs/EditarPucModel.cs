namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Pucs;

public class EditarPucModel
{
    public int Id { get; set; }
    //public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int? IdPuctipo { get; set; }
    public int? IdTipocuenta { get; set; }
    public int? IdTipoimpuesto { get; set; }
    public bool PacActiva { get; set; }
    public bool PacBase { get; set; }
    public bool PacAjusteniif { get; set; }
    //public string IdUsuario { get; set; }
}