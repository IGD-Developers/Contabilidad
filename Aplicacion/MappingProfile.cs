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

namespace Aplicacion;

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
        .ForMember(x => x.tdebito, y => y.MapFrom(z => z.tdebito));
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
        .ForMember(x=> x.puccodigo, y => y.MapFrom(z=> z.puc.codigo))
        .ForMember(x=> x.pucnombre, y => y.MapFrom(z=> z.puc.nombre))
        .ForMember(x=> x.tipoimpuestocodigo, y => y.MapFrom(z=> z.tipoImpuesto.codigo))
        .ForMember(x=> x.tipoimpuestonombre, y => y.MapFrom(z=> z.tipoImpuesto.nombre));


       
        //CreateMap<ListarCuentaImpuestosModel,CntCuentaImpuesto>();


        CreateMap<CntCategoriaComprobante, ListarCategoriaComprobantesModel>();
        CreateMap<CntTipoComprobante, CategoriaTipoComprobantesModel>();
        CreateMap<CntTercero, EntidadTerceroModel>();
        CreateMap<CntTipoImpuesto, EntidadImpuestoModel>();
        CreateMap<CntComprobante, ImpuestoComprobanteModel>();


       
        CreateMap<CntComprobante, ListarComprobantesModel>()
        .ForMember(x => x.tipoComprobante, y => y.MapFrom(z => z.tipoComprobante))
        .ForMember(x => x.sucursal, y => y.MapFrom(z => z.sucursal))
        .ForMember(x => x.usuario, y => y.MapFrom(z => z.usuario))
        .ForMember(x => x.comprobanteDetalleComprobantes, y => y.MapFrom(z => z.comprobanteDetalleComprobantes));

        CreateMap<CnfEmpresa, ListarEmpresasModel>()
        .ForMember(x => x.nombregerente, y => y.MapFrom(z => z.terceroEmpresa));

        CreateMap<CntTercero, gerenteEmpresaModel>();

        CreateMap<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>()
        .ForMember(u => u.nombreUsuario, y => y.MapFrom(z => z.comprobante.usuario.tercero.ter_razonsocial));

        CreateMap<CntTercero, LiquidaImpuestoTerceroModel>();
        CreateMap<CntTipoImpuesto, LiquidaTipoImpuestoModel>();
        CreateMap<CntComprobante, ImpuestoComprobanteModel>();
        CreateMap<CntTipoComprobante, ImpuestoTipoComprobanteModel>();



        //Lo siguiente sobra porque relaciona los nombres de campo iguales
        //.ForMember(x=>x.ter_razonsocial,y=>y.MapFrom(z=>z.ter_razonsocial));

        CreateMap<CntDetalleComprobante, ListarDetallesPreLiquidacionImpuestoModel>();



       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       
       //***************************************************
        CreateMap<CntTercero, ListarTerceroModel>()
        .ForMember(x=>x.generoModel, y => y.MapFrom(z=>z.genero))
        .ForMember(x=>x.tipoDocumentoModel, y => y.MapFrom(z => z.documentos))
        .ForMember(x=>x.municipioModel, y=>y.MapFrom(z=>z.municipio))
        .ForMember(x=>x.regimenModel, y=>y.MapFrom(z=>z.regimen))
        .ForMember(x=>x.tipoPersonaModel, y=>y.MapFrom(z=>z.tipoPersona))
        .ForMember(x=>x.ciiusModel, y=>y.MapFrom(z=>z.ciiu))
        .ForMember(x=>x.responsabilidadTerceroModels, y=>y.MapFrom(z=>z.responsabilidadTerceros));
                    
        CreateMap<CntGenero, GeneroModel>();
        
        CreateMap<CntTipoDocumento, TipoDocumentoModel>();
        
        CreateMap<CntDepartamento, DepartamentosModel>();

        CreateMap<CntMunicipio, MunicipioModel>()
        .ForMember(x=>x.departamentosModel, y=>y.MapFrom(z=>z.departamento));
        
        CreateMap<CntRegimen, RegimenModel>();
        
        CreateMap<CntTipoPersona, TipoPersonaModel>();

        CreateMap<CntCiiu, CiiuModel>()
        .ForMember(x=>x.seccionCiiusModel, y=>y.MapFrom(z=>z.ciiuSeccionCiiu))
        .ForMember(x=>x.tipoCiiusModel, y=>y.MapFrom(z=>z.ciiuTipoCiiu));            

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
        .ForMember(x=>x.notaAclaratoriaTipoModel, y=>y.MapFrom(z=>z.notaAclaratoriaTipo))
        .ForMember(x=>x.pucModel, y=>y.MapFrom(z=>z.cntPuct)) ;

        CreateMap<CntNotaAclaratoriaTipo, NotaAclaratoriaTipoModel>();
        CreateMap<CntPuc, ListarPucNotaAclaratoriaModel>();
        CreateMap<InsertarNotaAclaratoriaModel, CntNotaAclaratoria>();
        CreateMap<EditarNotaAclaratoriaModel, CntNotaAclaratoria>();
        CreateMap<ActivarInactivarNotaAclaratoriaModel, CntNotaAclaratoria>();

        //*****
        
    }
}