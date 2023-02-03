namespace Aplicacion.Models.Contabilidad.Anos
{
    public class InsertarAnoModel
    {
            public int IdComprobante { get; set; }
            public int AnoAno { get; set; }
            public bool AnoCerrado { get; set; }
            public string Estado { get; set; }
            public string IdUsuario { get; set; }
    }
}