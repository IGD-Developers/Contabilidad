using System;
using Aplicacion.Models.Configuracion.Sucursales;
using Aplicacion.Models.Configuracion.Usuarios;
using Aplicacion.Models.Contabilidad.TipoComprobantes;

namespace Aplicacion.Models.Contabilidad.Comprobantes;

public class RevertirComprobantesModel
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
    public DateTime CcoFecha { get; set; }
    public string CcoDocumento { get; set; }
    public string CcoDetalle { get; set; }
    public string IdUsuario { get; set; }
  
    
}