namespace Dominio.Contabilidad
{
    public class CntNotaAclaratoriaCuenta
    {

        public int id { get; set; }
        public int id_notaaclaratoria { get; set; }
        public int id_puc { get; set; }

        public CntNotaAclaratoria cntNotaAclaratoria { get; set; }
        public CntPuc cntPuc { get; set; }

    }
}