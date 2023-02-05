using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Usuarios;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;

public class EditarComprobantesModel
{
    public int Id { get; set; }
    //public int? IdSucursal { get; set; }
    public int? IdModulo { get; set; }
    public int? IdTercero { get; set; }
    //public int? IdReversion { get; set; }
    public DateTime? CcoFecha { get; set; }
    public string CcoDocumento { get; set; }
    public string CcoDetalle { get; set; }

    public ICollection<EditarDetalleComprobantesModel> ComprobanteDetalleComprobantes { get; set; }

    public TipoComprobanteModel TipoComprobante { get; set; }
    public SucursalModel Sucursal { get; set; }
    public UsuarioModel Usuario { get; set; }


    //public ICollection<InsertarDetalleComprobanteModel> detalleComprobante { get; set; }
}