using System;
using System.Collections.Generic;
using Aplicacion.Models.Configuracion.Sucursales;
using Aplicacion.Models.Configuracion.Usuarios;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Aplicacion.Models.Contabilidad.TipoComprobantes;


namespace Aplicacion.Models.Contabilidad.Comprobantes;

public class EditarComprobantesModel
{
    public int Id { get; set; }
    //public int? id_sucursal { get; set; }
    public int? id_modulo { get; set; }
    public int? id_tercero { get; set; }
    //public int? id_reversion { get; set; }
    public DateTime? cco_fecha { get; set; }
    public string cco_documento { get; set; }
    public string cco_detalle { get; set; }

    public ICollection<EditarDetalleComprobantesModel> comprobanteDetalleComprobantes { get; set; }

    public TipoComprobanteModel tipoComprobante { get; set; }
    public SucursalModel sucursal { get; set; }
    public UsuarioModel usuario { get; set; }


    //public ICollection<InsertarDetalleComprobanteModel> detalleComprobante { get; set; }


}