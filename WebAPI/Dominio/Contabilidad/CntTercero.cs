namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntTercero
{
    public int Id { get; set; }
    public int IdTippersona { get; set; }
    public int IdGenero { get; set; }
    public int IdTipodocumento { get; set; }
    public int IdMunicipio { get; set; }
    public int IdRegimen { get; set; }
    public int IdCiiu { get; set; }
    public string IdUsuario { get; set; }
    //TODO:Pendiente para agregar Usuario que edita el Tercero

    public string TerDocumento { get; set; }
    public string TerDigitoverificacion { get; set; }
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
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public CntGenero Genero { get; set; }
    public CntTipoDocumento Documentos { get; set; }
    public CntMunicipio Municipio { get; set; }
    public CntRegimen Regimen { get; set; }
    public CntTipoPersona TipoPersona { get; set; }
    public CntCiiu Ciiu { get; set; }
    public ICollection<CntResponsabilidadTer> ResponsabilidadTerceros { get; set; }
    public ICollection<CntEntidad> EntidadTerceros { get; set; }
    public ICollection<CntLiquidaImpuesto> LiquidaImpuestoTerceros { get; set; }

    public CnfEmpresa EmpresaTercero { get; set; }

    public ICollection<CnfUsuario> UsuarioTerceros { get; set; }

    public ICollection<CntDetalleComprobante> DetalleComprobanteTerceros { get; set; }
}