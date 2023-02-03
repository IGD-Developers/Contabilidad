using System;
using Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;
using Aplicacion.Models.Contabilidad.Pucs;

namespace Aplicacion.Models.Contabilidad.NotaAclaratoria
{
    public class ListarNotaAclaratoriaModel
    {
        public int id { get; set; }
        public int nac_consecutivo { get; set; }
        public DateTime nac_fecha { get; set; }
        public int? id_puc { get; set; }
        public int id_notaaclaratoriatipo { get; set; }
        public string nac_titulo { get; set; }
        public string nac_detalle { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }

        public NotaAclaratoriaTipoModel notaAclaratoriaTipoModel {get; set;}
        public ListarPucNotaAclaratoriaModel pucModel {get; set;}     }
}