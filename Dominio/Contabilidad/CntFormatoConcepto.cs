namespace Dominio.Contabilidad
{
    public class CntFormatoConcepto
    {
        public int id { get; set; }
        public int id_exogenaformato { get; set; }
        public int id_exogenaconcepto { get; set; }

        public CntExogenaFormato exogenaFormato { get; set; }
        public CntExogenaConcepto exogenaConcepto { get; set; }

    }
}