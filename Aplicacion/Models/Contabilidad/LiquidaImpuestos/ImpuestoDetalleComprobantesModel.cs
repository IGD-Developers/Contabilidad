namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos;


/// <summary>ImpuestoDetalleComprobantesModel: 
 ///Modelo para obtener el detalle del comprobante generado al liquidar impuesto.<para> </para>
 ///Vista de consulta General.<para> </para>
 /// Data desde CntDetalleComprobante.
 ///</summary>
public class ImpuestoDetalleComprobantesModel
{
    public int id { get; set; }
    public int id_comprobante { get; set; }
    public int id_centrocosto { get; set; }
    public int id_puc { get; set; }
    public int id_tercero { get; set; }
    public double dco_base { get; set; }
    public double dco_tarifa { get; set; }
    public double dco_debito { get; set; }
    public double dco_credito { get; set; }
    public string dco_detalle { get; set; }
    
}