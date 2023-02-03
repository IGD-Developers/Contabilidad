using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;

namespace Aplicacion.Models.Contabilidad.Tercero;

public class EditarJuridicoModel
{
    public int Id { get; set; }
    public int ? id_tippersona { get; set; }
    public int ? id_genero { get; set; }
    public int ? id_tipodocumento { get; set; }
    public int ? id_municipio { get; set; }
    public int ? id_regimen { get; set; }
    public int ? id_ciiu { get; set; }
    public string id_usuario { get; set; } 
    public string ter_documento { get; set; }
    public string ter_digitoverificacion {get; set;}
    public string ter_razonsocial { get; set; }
    public string ter_direccion { get; set; }
    public string ter_barrio { get; set; }
    public string ter_telfijo { get; set; }
    public string ter_telcelular { get; set; }
    public string ter_email { get; set; }
    public string ter_email_fe { get; set; }
    public string ter_contacto_fe { get; set; }
    public ICollection<EditarResponsabilidadTerceroJuridicoModel> responsabilidadTerceroJuridicoModel { get; set; }
}