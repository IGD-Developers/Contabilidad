using System.Collections;
using System.Collections.Generic;
using Aplicacion.Models.Contabilidad.Departamentos;
using Aplicacion.Models.Contabilidad.Genero;
using Aplicacion.Models.Contabilidad.Municipios;
using Aplicacion.Models.Contabilidad.Regimen;
using Aplicacion.Models.Contabilidad.TipoDocumento;
using Aplicacion.Models.Contabilidad.TipoPersona;
using Aplicacion.Models.Contabilidad.Ciius;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using Aplicacion.Models.Contabilidad.Entidades;

namespace Aplicacion.Models.Contabilidad.Tercero
{
    public class ListarTerceroModel
    {
        public int id { get; set; }
        public int id_tippersona { get; set; }
        public int id_genero { get; set; }
        public int id_tipodocumento { get; set; }
        public int id_municipio { get; set; }
        public int id_regimen { get; set; }
        public int id_ciiu { get; set; }
        public string id_usuario { get; set; } 
        public string ter_documento { get; set; }
        public string ter_digitoverificacion { get; set; }
        //public string ter_digi{get; set;}
        public string ter_prinombre { get; set; }
        public string ter_segnombre { get; set; }
        public string ter_priapellido { get; set; }
        public string ter_segapellido { get; set; }
        public string ter_razonsocial { get; set; }
        public string ter_direccion { get; set; }
        public string ter_barrio { get; set; }
        public string ter_telfijo { get; set; }
        public string ter_telcelular { get; set; }
        public string ter_email { get; set; }
        public string ter_email_fe { get; set; }
        public string ter_contacto_fe { get; set; }

        public GeneroModel generoModel { get; set; }
        public TipoDocumentoModel tipoDocumentoModel { get; set; }
        public MunicipioModel municipioModel {get; set;}
        public RegimenModel regimenModel {get;set;}
        public TipoPersonaModel tipoPersonaModel { get; set; }
        public CiiuModel ciiusModel { get; set; }
        public ICollection<ResponsabilidadTerceroModel> responsabilidadTerceroModels { get; set; }
        //public ICollection<EntidadModel> entidadModel { get; set; }


    }
}