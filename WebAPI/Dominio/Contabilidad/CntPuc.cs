namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntPuc
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int? IdPuctipo { get; set; }
    public int? IdTipocuenta { get; set; }
    public int? IdTipoimpuesto { get; set; }
    public bool PacActiva { get; set; }
    public bool PacBase { get; set; }
    public bool PacAjusteniif { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }

    public CntPucTipo PucTipo { get; set; }
    public CntTipoCuenta TipoCuenta { get; set; }
    public CntTipoImpuesto TipoImpuesto { get; set; }
    public CnfUsuario Usuario { get; set; }

    public ICollection<CntCuentaImpuesto> PucCuentaImpuestos { get; set; }

    public ICollection<CntDetalleComprobante> PucDetalleComprobantes { get; set; }
    public ICollection<CntNotaAclaratoriaCuenta> PucNotaAclaratoriaCuentas { get; set; }

    public ICollection<CntLiquidaImpuesto> PucLiquidaImpuestos { get; set; }
    public ICollection<CntNotaAclaratoria> PucNotaAclaratoria { get; set; }
}