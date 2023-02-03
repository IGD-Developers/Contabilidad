using Aplicacion.Models.Contabilidad.Responsabilidad;

namespace Aplicacion.Models.Contabilidad.ResponsabilidadTercero;

public class ResponsabilidadTerceroModel
{
    public int id { get; set; }
    public int id_tercero {get; set;}
    //public int id_responsabilidad {get; set;}
    public ResponsabilidadModel ResponsabilidadModel { get; set; }
}