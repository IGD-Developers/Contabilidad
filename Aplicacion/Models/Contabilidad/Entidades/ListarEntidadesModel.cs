namespace Aplicacion.Models.Contabilidad.Entidades
{
    public class ListarEntidadesModel
    {
        public int id { get; set; }
        public int id_tercero { get; set; }
        public int id_tipoimpuesto { get; set; }

        public EntidadTerceroModel tercero { get; set; }
        public EntidadImpuestoModel tipoImpuesto { get; set; }
    }
}