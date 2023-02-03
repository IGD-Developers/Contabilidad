using System.Linq;
using Aplicacion.Contabilidad.Pucs;
using Aplicacion.Models.Configuracion.Empresas;
using Aplicacion.Models.Configuracion.Sucursales;
using Aplicacion.Models.Configuracion.Usuarios;
using Aplicacion.Models.Contabilidad.Anos;
using Aplicacion.Models.Contabilidad.Bancos;
using Aplicacion.Models.Contabilidad.CategoriaComprobantes;
using Aplicacion.Models.Contabilidad.CentroCostos;
using Aplicacion.Models.Contabilidad.Ciius;
using Aplicacion.Models.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.CuentaImpuestos;
using Aplicacion.Models.Contabilidad.Departamentos;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Aplicacion.Models.Contabilidad.Entidades;
using Aplicacion.Models.Contabilidad.Genero;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using Aplicacion.Models.Contabilidad.Municipios;
using Aplicacion.Models.Contabilidad.NotaAclaratoria;
using Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;
using Aplicacion.Models.Contabilidad.Pucs;
using Aplicacion.Models.Contabilidad.PucTipos;
using Aplicacion.Models.Contabilidad.Regimen;
using Aplicacion.Models.Contabilidad.Responsabilidad;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using Aplicacion.Models.Contabilidad.SeccionCiius;
using Aplicacion.Models.Contabilidad.Tercero;
using Aplicacion.Models.Contabilidad.TipoCiius;
using Aplicacion.Models.Contabilidad.TipoComprobantes;
using Aplicacion.Models.Contabilidad.TipoCuentas;
using Aplicacion.Models.Contabilidad.TipoDocumento;
using Aplicacion.Models.Contabilidad.TipoImpuestos;
using Aplicacion.Models.Contabilidad.TipoPersona;
using AutoMapper;
using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<CntPuc, ListarPucModel>();
            CreateMap<CntBanco, ListarBancosModel>();
            CreateMap<CnfSucursal, ListarSucursalModel>();
            CreateMap<CntCentroCosto, ListarCentroCostosModel>();
            CreateMap<CntCategoriaComprobante, ListarCategoriaComprobantesModel>();
            CreateMap<CntEntidad, ListarEntidadesModel>();
            
            CreateMap<InsertarSucursalModel, CnfSucursal>();
            CreateMap<InsertarEmpresasModel, CnfEmpresa>();
            CreateMap<InsertarAnoModel, CntAno>();
            CreateMap<InsertarBancosModel, CntBanco>();
            CreateMap<InsertarTipoComprobanteModel, CntTipoComprobante>();
            CreateMap<InsertarCentroCostosModel, CntCentroCosto>();
            CreateMap<InsertarCategoriaComprobantesModel, CntCategoriaComprobante>();
            CreateMap<InsertarEntidadModel, CntEntidad>();
            CreateMap<InsertarPucModel, CntPuc>();
            CreateMap<InsertarTipoImpuestosModel, CntTipoImpuesto>();
            CreateMap< InsertarComprobantesModel,CntComprobante>()
            .ForMember(x => x.Tdebito, y => y.MapFrom(z => z.Tdebito));
;
            CreateMap< InsertarDetalleComprobanteModel,CntDetalleComprobante>();
            CreateMap< InsertarLiquidaImpuestosModel,CntLiquidaImpuesto>();
            //CreateMap< InsertarLiquidaImpuestosModel,CntComprobante>();

            CreateMap<EditarSucursalModel, CnfSucursal>();
            CreateMap<EditarBancosModel, CntBanco>();
            CreateMap<EditarEmpresasModel, CnfEmpresa>();
            CreateMap<EditarTipoComprobanteModel, CntTipoComprobante>();
            CreateMap<EditarCentroCostosModel, CntCentroCosto>();
            CreateMap<EditarCategoriaComprobantesModel, CntCategoriaComprobante>();
            CreateMap<EditarEntidadModel, CntEntidad>();
            CreateMap<EditarPucModel, CntPuc>();
            CreateMap<EditarComprobantesModel, CntComprobante>();
            CreateMap<EditarDetalleComprobantesModel, CntDetalleComprobante>();
            CreateMap<EditarTipoImpuestosModel, CntTipoImpuesto>();

            CreateMap<CnfUsuario, UsuarioModel>();
            CreateMap<CntTipoCuenta, TipoCuentaModel>();
            CreateMap<CntPucTipo, PucTipoModel>();
            CreateMap<CnfSucursal, SucursalModel>();
            CreateMap<CnfEmpresa, EmpresasModel>();
            CreateMap<CntTipoComprobante, TipoComprobanteModel>();
            CreateMap<CntDetalleComprobante, ListarDetalleComprobantesModel>();
            CreateMap<CntDetalleComprobante, InsertarDetalleComprobanteModel>();
            CreateMap<CntTipoComprobante, ListarTipoComprobanteModel>();
            CreateMap<CntCategoriaComprobante, CategoriaComprobanteModel>();
            CreateMap<CntTipoImpuesto, ListarTipoImpuestosModel>();
            
            CreateMap<CntCuentaImpuesto, ListarCuentaImpuestosModel>()
            .ForMember(x=> x.PucCodigo, y => y.MapFrom(z=> z.Puc.Codigo))
            .ForMember(x=> x.PucNombre, y => y.MapFrom(z=> z.Puc.Nombre))
            .ForMember(x=> x.TipoImpuestoCodigo, y => y.MapFrom(z=> z.TipoImpuesto.Codigo))
            .ForMember(x=> x.TipoImpuestoNombre, y => y.MapFrom(z=> z.TipoImpuesto.Nombre));


           
            //CreateMap<ListarCuentaImpuestosModel,CntCuentaImpuesto>();


            CreateMap<CntCategoriaComprobante, ListarCategoriaComprobantesModel>();
            CreateMap<CntTipoComprobante, CategoriaTipoComprobantesModel>();
            CreateMap<CntTercero, EntidadTerceroModel>();
            CreateMap<CntTipoImpuesto, EntidadImpuestoModel>();
            CreateMap<CntComprobante, ImpuestoComprobanteModel>();


           
            CreateMap<CntComprobante, ListarComprobantesModel>()
            .ForMember(x => x.TipoComprobante, y => y.MapFrom(z => z.TipoComprobante))
            .ForMember(x => x.Sucursal, y => y.MapFrom(z => z.Sucursal))
            .ForMember(x => x.Usuario, y => y.MapFrom(z => z.Usuario))
            .ForMember(x => x.ComprobanteDetalleComprobantes, y => y.MapFrom(z => z.ComprobanteDetalleComprobantes));

            CreateMap<CnfEmpresa, ListarEmpresasModel>()
            .ForMember(x => x.NombreGerente, y => y.MapFrom(z => z.TerceroEmpresa));

            CreateMap<CntTercero, GerenteEmpresaModel>();

            CreateMap<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>()
            .ForMember(u => u.NombreUsuario, y => y.MapFrom(z => z.Comprobante.Usuario.Tercero.TerRazonsocial));

            CreateMap<CntTercero, LiquidaImpuestoTerceroModel>();
            CreateMap<CntTipoImpuesto, LiquidaTipoImpuestoModel>();
            CreateMap<CntComprobante, ImpuestoComprobanteModel>();
            CreateMap<CntTipoComprobante, ImpuestoTipoComprobanteModel>();



            //Lo siguiente sobra porque relaciona los nombres de campo iguales
            //.ForMember(x=>x.TerRazonsocial,y=>y.MapFrom(z=>z.TerRazonsocial));

            CreateMap<CntDetalleComprobante, ListarDetallesPreLiquidacionImpuestoModel>();
     
           //***************************************************
            CreateMap<CntTercero, ListarTerceroModel>()
            .ForMember(x=>x.GeneroModel, y => y.MapFrom(z=>z.Genero))
            .ForMember(x=>x.TipoDocumentoModel, y => y.MapFrom(z => z.Documentos))
            .ForMember(x=>x.MunicipioModel, y=>y.MapFrom(z=>z.Municipio))
            .ForMember(x=>x.RegimenModel, y=>y.MapFrom(z=>z.Regimen))
            .ForMember(x=>x.TipoPersonaModel, y=>y.MapFrom(z=>z.TipoPersona))
            .ForMember(x=>x.CiiusModel, y=>y.MapFrom(z=>z.Ciiu))
            .ForMember(x=>x.ResponsabilidadTerceroModels, y=>y.MapFrom(z=>z.ResponsabilidadTerceros));
                        
            CreateMap<CntGenero, GeneroModel>();
            
            CreateMap<CntTipoDocumento, TipoDocumentoModel>();
            
            CreateMap<CntDepartamento, DepartamentosModel>();

            CreateMap<CntMunicipio, MunicipioModel>()
            .ForMember(x=>x.DepartamentosModel, y=>y.MapFrom(z=>z.Departamento));
            
            CreateMap<CntRegimen, RegimenModel>();
            
            CreateMap<CntTipoPersona, TipoPersonaModel>();

            CreateMap<CntCiiu, CiiuModel>()
            .ForMember(x=>x.SeccionCiiusModel, y=>y.MapFrom(z=>z.CiiuSeccionCiiu))
            .ForMember(x=>x.TipoCiiusModel, y=>y.MapFrom(z=>z.CiiuTipoCiiu));            

            CreateMap<CntSeccionCiiu, SeccionCiiusModel>();

            CreateMap<CntTipoCiiu, TipoCiiusModel>();       

            CreateMap<CntResponsabilidadTer, ResponsabilidadTerceroModel>()
            .ForMember(x=>x.ResponsabilidadModel, y=>y.MapFrom(z=>z.Responsabilidad));

            CreateMap<CntResponsabilidad, ResponsabilidadModel>();   
            CreateMap<CntEntidad, EntidadModel>();
            
            CreateMap<InsertarTerceroModel, CntTercero>();
            CreateMap<InsertarJuridicoModel, CntTercero>();            
            CreateMap<EditarTerceroModel, CntTercero>();
            CreateMap<EditarJuridicoModel, CntTercero>();
            
            CreateMap<InsertarResponsabilidadTerceroModel, CntResponsabilidadTer>();
            CreateMap<EditarResponsabilidadTerceroModel, CntResponsabilidadTer>();
            CreateMap<EditarResponsabilidadTerceroJuridicoModel, CntResponsabilidadTer>();

            CreateMap<CntNotaAclaratoria, ListarNotaAclaratoriaModel>()
            .ForMember(x=>x.NotaAclaratoriaTipoModel, y=>y.MapFrom(z=>z.NotaAclaratoriaTipo))
            .ForMember(x=>x.PucModel, y=>y.MapFrom(z=>z.CntPuct)) ;

            CreateMap<CntNotaAclaratoriaTipo, NotaAclaratoriaTipoModel>();
            CreateMap<CntPuc, ListarPucNotaAclaratoriaModel>();
            CreateMap<InsertarNotaAclaratoriaModel, CntNotaAclaratoria>();
            CreateMap<EditarNotaAclaratoriaModel, CntNotaAclaratoria>();
            CreateMap<ActivarInactivarNotaAclaratoriaModel, CntNotaAclaratoria>();

            //*****
            
        }
    }
}