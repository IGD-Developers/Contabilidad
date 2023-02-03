namespace Dominio.Contabilidad
{
    public class CntFormatoColumna
    {
        public int Id { get; set; }
        public int IdExogenaformato { get; set; }
        public string FcoColumna { get; set; }
        public string FcoCampo { get; set; }
        public string FcoTipo { get; set; }

        public CntExogenaFormato ExogenaFormato { get; set; }

    }
}