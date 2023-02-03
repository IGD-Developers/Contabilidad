namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos
{

    /// <summary>ImpuestoDetalleComprobantesModel: 
     ///Modelo para obtener el detalle del Comprobante generado al liquidar impuesto.<para> </para>
     ///Vista de consulta General.<para> </para>
     /// Data desde CntDetalleComprobante.
     ///</summary>
    public class ImpuestoDetalleComprobantesModel
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
        
    }
}