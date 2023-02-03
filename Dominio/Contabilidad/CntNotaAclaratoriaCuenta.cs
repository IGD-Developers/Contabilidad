namespace Dominio.Contabilidad
{
    public class CntNotaAclaratoriaCuenta
    {

        public int Id { get; set; }
        public int IdNotaaclaratoria { get; set; }
        public int IdPuc { get; set; }

        public CntNotaAclaratoria CntNotaAclaratoria { get; set; }
        public CntPuc CntPuc { get; set; }

    }
}