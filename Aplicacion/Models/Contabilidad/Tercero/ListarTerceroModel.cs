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
        public int Id { get; set; }
        public int IdTippersona { get; set; }
        public int IdGenero { get; set; }
        public int IdTipodocumento { get; set; }
        public int IdMunicipio { get; set; }
        public int IdRegimen { get; set; }
        public int IdCiiu { get; set; }
        public string IdUsuario { get; set; } 
        public string TerDocumento { get; set; }
        public string TerDigitoverificacion { get; set; }
        //public string ter_digi{get; set;}
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

        public GeneroModel GeneroModel { get; set; }
        public TipoDocumentoModel TipoDocumentoModel { get; set; }
        public MunicipioModel MunicipioModel {get; set;}
        public RegimenModel RegimenModel {get;set;}
        public TipoPersonaModel TipoPersonaModel { get; set; }
        public CiiuModel CiiusModel { get; set; }
        public ICollection<ResponsabilidadTerceroModel> ResponsabilidadTerceroModels { get; set; }
        //public ICollection<EntidadModel> entidadModel { get; set; }


    }
}