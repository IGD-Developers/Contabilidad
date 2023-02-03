using System;

namespace Aplicacion.Models.Contabilidad.NotaAclaratoria
{
    public class EditarNotaAclaratoriaModel
    {
        public int ID {get; set;}
        public int nac_consecutivo { get; set; }
        public DateTime? nac_fecha { get; set; }
        public int? id_puc { get; set; }
        public int? id_notaaclaratoriatipo { get; set; }
        public string nac_titulo { get; set; }
        public string nac_detalle { get; set; }
        public string id_usuario { get; set; }
    }
}