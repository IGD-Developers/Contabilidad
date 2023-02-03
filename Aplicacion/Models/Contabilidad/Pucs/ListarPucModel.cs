
namespace Aplicacion.Models.Contabilidad.Pucs
{
    public class ListarPucModel
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int? id_puctipo { get; set; }
        public int? id_tipocuenta { get; set; }
        public int? id_tipoimpuesto { get; set; }
        public bool pac_activa { get; set; }
        public bool pac_base { get; set; }
        public bool pac_ajusteniif { get; set; }

        public string clase { get; set; }
        public string grupo { get; set; }
        public string cuenta { get; set; }
        public string subcuenta { get; set; }
        
        
        public PucTipos.PucTipoModel pucTipo { get; set; }
        public TipoCuentas.TipoCuentaModel tipoCuenta { get; set; }


        
    }
}