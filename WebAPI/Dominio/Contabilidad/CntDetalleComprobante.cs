namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntDetalleComprobante
{
    public int Id { get; set; }
    public int IdComprobante { get; set; }
    public int IdCentrocosto { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    public double DcoBase { get; set; }
    public double DcoTarifa { get; set; }
    public double DcoDebito { get; set; }
    public double DcoCredito { get; set; }
    public string DcoDetalle { get; set; }

    public CntComprobante Comprobante { get; set; }
    public CntCentroCosto CentroCosto { get; set; }
    public CntPuc Puc { get; set; }
    public CntTercero Tercero { get; set; }
}