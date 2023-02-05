#nullable disable

namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntComprobante
{
    public int Id { get; set; }
    public int IdSucursal { get; set; }
    public int IdTipocomprobante { get; set; }
    public int IdModulo { get; set; }
    public int IdTercero { get; set; }
    public int? IdReversion { get; set; }
    public string CcoAno { get; set; }
    public string CcoMes { get; set; }
    public int CcoConsecutivo { get; set; }
    public DateTime? CcoFecha { get; set; }
    public string CcoDocumento { get; set; }
    public string CcoDetalle { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Estado { get; set; }
    public string IdUsuario { get; set; }
    public double Tdebito
    {
        get
        {
            if (ComprobanteDetalleComprobantes != null)
            {
                return ComprobanteDetalleComprobantes.Sum(d => d.DcoDebito);
            }
            return 0;
        }
    }

    public double Tcredito
    {
        get
        {
            if (ComprobanteDetalleComprobantes != null)
            {
                return ComprobanteDetalleComprobantes.Sum(d => d.DcoCredito);
            }
            return 0;
        }
    }




    public CnfUsuario Usuario { get; set; }
    public CntTipoComprobante TipoComprobante { get; set; }
    public CnfSucursal Sucursal { get; set; }
    public ICollection<CntDetalleComprobante> ComprobanteDetalleComprobantes { get; set; }
    public ICollection<CntAno> ComprobanteAnos { get; set; }
    public ICollection<CntLiquidaImpuesto> ComprobanteLiquidaImpuestos { get; set; }











}