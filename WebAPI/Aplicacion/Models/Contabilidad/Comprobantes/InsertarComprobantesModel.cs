using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;

public class InsertarComprobantesModel
{

    public int IdSucursal { get; set; }
    public int IdTipocomprobante { get; set; }
    public int IdModulo { get; set; }
    public int IdTercero { get; set; }
    public int? IdReversion { get; set; }
    public string CcoAno { get; set; }
    public string CcoMes { get; set; }
    public int CcoConsecutivo { get; set; }
    public DateTime CcoFecha { get; set; }
    public string CcoDocumento { get; set; }
    public string CcoDetalle { get; set; }
    public string IdUsuario { get; set; }
    public double Tdebito { get; set; }
    public double Tcredito { get; set; }

    public ICollection<InsertarDetalleComprobanteModel> ComprobanteDetalleComprobantes { get; set; }

}