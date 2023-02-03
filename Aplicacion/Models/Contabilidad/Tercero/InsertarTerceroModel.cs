using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;

namespace Aplicacion.Models.Contabilidad.Tercero;

public class InsertarTerceroModel
{
    public int? IdTippersona { get; set; }
    public int? IdGenero { get; set; }
    public int? IdTipodocumento { get; set; }
    public int? IdMunicipio { get; set; }
    public int? IdRegimen { get; set; }
    public int? IdCiiu { get; set; }
    public string IdUsuario { get; set; } 
    public string TerDocumento { get; set; }
    public string TerDigitoverificacion {get; set;}
    //public string digitoverificacion {get; set;}
    public string TerPrinombre { get; set; }
    public string TerSegnombre { get; set; }
    public string TerPriapellido { get; set; }
    public string TerSegapellido { get; set; }
    public string TerRazonsocial { get; set; }
    public string TerDireccion { get; set; }
    public string TerBarrio { get; set; }
    public string TerTelfijo { get; set; }
    public string TerTelcelular { get; set; }
    public string TerEmail { get; set; }
    public string TerEmailFe { get; set; }
    public string TerContactoFe { get; set; }

    public ICollection<InsertarResponsabilidadTerceroModel> ResponsabilidadTerceroModel { get; set; }
}