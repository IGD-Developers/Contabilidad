using Aplicacion.Models.Contabilidad.SeccionCiius;
using Aplicacion.Models.Contabilidad.TipoCiius;

namespace Aplicacion.Models.Contabilidad.Ciius
{
    public class CiiuModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdTipociuu { get; set; }
        public int IdSeccionciiu { get; set; }
        public SeccionCiiusModel SeccionCiiusModel { get; set; }
        public TipoCiiusModel TipoCiiusModel { get; set; }
    }
}