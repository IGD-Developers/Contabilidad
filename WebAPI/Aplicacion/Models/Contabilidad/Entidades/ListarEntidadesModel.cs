namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;

public class ListarEntidadesModel
{
    public int Id { get; set; }
    public int IdTercero { get; set; }
    public int IdTipoimpuesto { get; set; }

    public EntidadTerceroModel Tercero { get; set; }
    public EntidadImpuestoModel TipoImpuesto { get; set; }
}