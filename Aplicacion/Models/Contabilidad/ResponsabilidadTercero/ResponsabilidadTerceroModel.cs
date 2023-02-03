using Aplicacion.Models.Contabilidad.Responsabilidad;

namespace Aplicacion.Models.Contabilidad.ResponsabilidadTercero;

public class ResponsabilidadTerceroModel
{
    public int Id { get; set; }
    public int IdTercero {get; set;}
    //public int IdResponsabilidad {get; set;}
    public ResponsabilidadModel ResponsabilidadModel { get; set; }
}