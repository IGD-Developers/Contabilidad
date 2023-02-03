using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Persistencia.Mapeo.Contabilidad;
using Persistencia.Mapeo.Configuracion;
using Dominio.Contabilidad;
using Dominio.Configuracion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistencia;

public class CntContext : IdentityDbContext<CnfUsuario>
{
    public CntContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //enviamos a la Clase padre el modelBuilder como parametro
       
        modelBuilder.ApplyConfiguration(new ComprobanteMap());
        modelBuilder.ApplyConfiguration(new TipoComprobanteMap());
        modelBuilder.ApplyConfiguration(new CategoriaComprobanteMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new EmpresaMap());
        modelBuilder.ApplyConfiguration(new PucMap());
        modelBuilder.ApplyConfiguration(new PucTipoMap());
        modelBuilder.ApplyConfiguration(new TipoCuentaMap());
        modelBuilder.ApplyConfiguration(new CuentaImpuestoMap());
        modelBuilder.ApplyConfiguration(new TipoImpuestoMap());
        modelBuilder.ApplyConfiguration(new CentroCostoMap());
        modelBuilder.ApplyConfiguration(new DetalleComprobantMap());
        modelBuilder.ApplyConfiguration(new ConceptoCuentaMap());
        modelBuilder.ApplyConfiguration(new FormatoColumnaMap());
        modelBuilder.ApplyConfiguration(new ExogenaFormatoMap());
        modelBuilder.ApplyConfiguration(new FormatoConceptoMap());
        modelBuilder.ApplyConfiguration(new ExogenaConceptoMap());
        modelBuilder.ApplyConfiguration(new TipoOperacionMap());
        modelBuilder.ApplyConfiguration(new NotaAclaratoriaTipoMap());
        modelBuilder.ApplyConfiguration(new NotaAclaratoriaMap());
        modelBuilder.ApplyConfiguration(new AnoMap());
        modelBuilder.ApplyConfiguration(new BancoMap());
        modelBuilder.ApplyConfiguration(new ConsecutivoMap());
        modelBuilder.ApplyConfiguration(new EntidadMap());
        modelBuilder.ApplyConfiguration(new LiquidaImpuestoMap());
        modelBuilder.ApplyConfiguration(new MesMap());
        modelBuilder.ApplyConfiguration(new NotaAclaratoriaCuentaMap());
        modelBuilder.ApplyConfiguration(new UvtMap());
        modelBuilder.ApplyConfiguration(new SucursalMap());             


        modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
        modelBuilder.ApplyConfiguration(new TerceroMap());
        modelBuilder.ApplyConfiguration(new TipoPersonaMap());
        modelBuilder.ApplyConfiguration(new GeneroMap());            
        modelBuilder.ApplyConfiguration(new DepartamentoMap());            
        modelBuilder.ApplyConfiguration(new MunicipioMap());            
        modelBuilder.ApplyConfiguration(new RegimenMap());            
        modelBuilder.ApplyConfiguration(new CiiuMap());            
        modelBuilder.ApplyConfiguration(new SeccionCiiuMap());            
        modelBuilder.ApplyConfiguration(new TipoCiiuMap());            
        modelBuilder.ApplyConfiguration(new ResponsabilidadMap());            
        modelBuilder.ApplyConfiguration(new ResponsabilidadTerMap());             



    }

   

    public DbSet<CntComprobante> cntComprobantes {get;set;}
    public DbSet<CntTipoComprobante> cntTipoComprobantes {get;set;}
    public DbSet<CntConsecutivo> cntConsecutivos { get; set; }

    public DbSet<CntCategoriaComprobante> cntCategoriaComprobantes {get;set;}
    public DbSet<CnfUsuario> cnfUsuarios {get;set;}

    public DbSet<CnfSucursal> cnfSucursales {get;set;}

    public DbSet<CnfEmpresa> cnfEmpresas {get;set;}


    public DbSet<CntPuc> cntPucs { get; set; }
    public DbSet<CntPucTipo> cntPucTipos { get; set; }
    public DbSet<CntTipoCuenta> cntTipoCuentas { get; set; }
    public DbSet<CntCuentaImpuesto> cntCuentaImpuestos { get; set; }
    public DbSet<CntTipoImpuesto> cntTipoImpuestos { get; set; }
    public DbSet<CntCentroCosto> cntCentroCostos { get; set; }

    public DbSet<CntDetalleComprobante> cntDetalleComprobantes { get; set; }

    public DbSet<CntExogenaFormato>  cntExogenaFormatos {get; set;}

    public DbSet<CntExogenaConcepto>  cntExogenaConceptos {get; set;}

    public DbSet<CntConceptoCuenta>  cntConceptoCuentas {get; set;}

    public DbSet<CntFormatoColumna>  cntFormatoColumnas {get; set;}

    public DbSet<CntFormatoConcepto>  cntFormatoConceptos {get; set;}

    public DbSet<CntTipoOperacion>  cntTipoOperaciones {get; set;}

    public DbSet<CntNotaAclaratoriaTipo>  cntNotaAclaratoriaTipos {get; set;}

    public DbSet<CntNotaAclaratoria> cntNotaAclaratorias  {get; set;}

    public DbSet<CntNotaAclaratoriaCuenta> cntNotaAclaratoriaCuentas  { get; set; }

    public DbSet<CntAno> cntAnos  { get; set; }
    public DbSet<CntBanco> cntBancos  { get; set; }
    public DbSet<CntEntidad> cntEntidades { get; set; }
    public DbSet<CntMes> cntMeses{ get; set; }
    public DbSet<CntLiquidaImpuesto> cntLiquidaImpuestos { get; set; }
    public DbSet<CntUvt> cntUvts { get; set; }
    
    //=====     
    public DbSet<CntTercero> CntTerceros {get;set;}
    public DbSet<CntTipoDocumento> CntTipoDocumentos {get;set;}
    public DbSet<CntTipoPersona> CntTipoPersonas {get;set;}
    public DbSet<CntGenero> CntGeneros {get;set;}
    public DbSet<CntDepartamento> CntDepartamentos {get;set;}
    public DbSet<CntMunicipio> CntMunucipios {get;set;}
    public DbSet<CntRegimen> CntRegimenes {get; set;}
    public DbSet<CntCiiu> CntCiius {get; set;}
    public DbSet<CntSeccionCiiu> CntSeccionCiius {get; set;}
    public DbSet<CntTipoCiiu> cntTipoCiius {get; set;}
    public DbSet<CntResponsabilidad> cntResponsabilidades {get; set;}        
    public DbSet<CntResponsabilidadTer> cntResponsabilidadTerceros {get; set;}


}    
