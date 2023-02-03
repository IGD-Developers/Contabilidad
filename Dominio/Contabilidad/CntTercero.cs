using System;
using System.Collections.Generic;
using Dominio.Configuracion;

namespace Dominio.Contabilidad
{
    public class CntTercero
    {
        public int id { get; set; }
        public int id_tippersona { get; set; }
        public int id_genero { get; set; }
        public int id_tipodocumento { get; set; }
        public int id_municipio { get; set; }
        public int id_regimen { get; set; }
        public int id_ciiu { get; set; }
        public string id_usuario { get; set; }
        //TODO:Pendiente para agregar usuario que edita el tercero

        public string ter_documento { get; set; }
        public string ter_digitoverificacion { get; set; }
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
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }


        public CntGenero genero { get; set; }
        public CntTipoDocumento documentos { get; set; }
        public CntMunicipio municipio { get; set; }
        public CntRegimen regimen { get; set; }
        public CntTipoPersona tipoPersona { get; set; }
        public CntCiiu ciiu { get; set; }
        public ICollection<CntResponsabilidadTer> responsabilidadTerceros { get; set; }
        public ICollection<CntEntidad> entidadTerceros { get; set; }
        public ICollection<CntLiquidaImpuesto> liquidaImpuestoTerceros { get; set; }

        public CnfEmpresa empresaTercero { get; set; }


        public ICollection<CnfUsuario> usuarioTerceros { get; set; }









        public ICollection<CntDetalleComprobante> detalleComprobanteTerceros { get; set; }
    }
}