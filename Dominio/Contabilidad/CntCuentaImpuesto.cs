namespace Dominio.Contabilidad
{
    public class CntCuentaImpuesto
    {
        public int Id { get; set; }
        public int IdPuc { get; set; }
        public int IdTipoimpuesto { get; set; }


        public CntPuc Puc { get; set; }
        public CntTipoImpuesto TipoImpuesto { get; set; }
    }
}