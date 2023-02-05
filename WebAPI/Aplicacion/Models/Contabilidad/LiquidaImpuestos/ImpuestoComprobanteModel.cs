namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;

/// <summary>ImpuestoComprobanteModel:<para> </para> 
///Modelo para obtener los datos del Comprobante y su total debito y credito
///que se genera al liquidar Impuesto. <para> </para>
///Data desde CntComprobantes. Incluye la relacion  a TipoComprobante y
///la Collection detalleComprobante</summary>
public class ImpuestoComprobanteModel
{
    public int IdSucursal { get; set; }
    public int IdTipocomprobante { get; set; }
    public string CcoAno { get; set; }
    public string CcoMes { get; set; }
    public int CcoConsecutivo { get; set; }
    public double Tdebito { get; set; }
    public double Tcredito { get; set; }
    //public string IdUsuario { get; set; }

    public ICollection<ImpuestoDetalleComprobantesModel> ComprobanteDetalleComprobantes { get; set; }
    public ImpuestoTipoComprobanteModel TipoComprobante { get; set; }

}