using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Configuracion;
#nullable disable

namespace Dominio.Contabilidad;

public class CntComprobante
{
    public int id { get; set; }
    public int id_sucursal { get; set; }
    public int id_tipocomprobante { get; set; }
    public int id_modulo { get; set; }
    public int id_tercero { get; set; }
    public int? id_reversion { get; set; }
    public string cco_ano { get; set; }
    public string cco_mes { get; set; }
    public int cco_consecutivo { get; set; }
    public DateTime? cco_fecha { get; set; }
    public string cco_documento { get; set; }
    public string cco_detalle { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public string estado { get; set; }
    public string id_usuario { get; set; }
    public double tdebito { get{
        if(comprobanteDetalleComprobantes!=null)
        {
            return comprobanteDetalleComprobantes.Sum(d => d.dco_debito);
        }
        return 0;
    }  }    

    public double tcredito { get{
        if(comprobanteDetalleComprobantes!=null)
        {
            return comprobanteDetalleComprobantes.Sum(d => d.dco_credito);
        }
        return 0;
    }  }    


       

    public CnfUsuario usuario { get; set; }
    public CntTipoComprobante tipoComprobante { get; set; }
    public CnfSucursal sucursal { get; set; }
    public ICollection<CntDetalleComprobante> comprobanteDetalleComprobantes { get; set; }
    public ICollection<CntAno> comprobanteAnos { get; set; }
    public ICollection<CntLiquidaImpuesto> comprobanteLiquidaImpuestos { get; set; }











}