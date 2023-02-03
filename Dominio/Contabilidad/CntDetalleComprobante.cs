namespace Dominio.Contabilidad
{
    public class CntDetalleComprobante
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

        public CntComprobante comprobante { get; set; }
        public CntCentroCosto centroCosto { get; set; }
        public CntPuc puc { get; set; }
        public CntTercero tercero { get; set; }




    }
}