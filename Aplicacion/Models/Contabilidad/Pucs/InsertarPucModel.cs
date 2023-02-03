namespace Aplicacion.Models.Contabilidad.Pucs
{
    public class InsertarPucModel
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int? id_puctipo { get; set; }
        public int? id_tipocuenta { get; set; }
        public int? id_tipoimpuesto { get; set; }
        public bool pac_activa { get; set; }
        public bool pac_base { get; set; }
        public bool pac_ajusteniif { get; set; }
        
        public string id_usuario { get; set; }
    }
}