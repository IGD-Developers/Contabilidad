using Aplicacion.Models.Contabilidad.SeccionCiius;
using Aplicacion.Models.Contabilidad.TipoCiius;

namespace Aplicacion.Models.Contabilidad.Ciius
{
    public class CiiuModel
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int id_tipociuu {get; set;}
        public int id_seccionciiu {get; set;}
        public SeccionCiiusModel seccionCiiusModel { get; set; }
        public TipoCiiusModel tipoCiiusModel { get; set; }
    }
}