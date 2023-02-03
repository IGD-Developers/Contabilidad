using System;
using Dominio.Configuracion;

namespace Dominio.Contabilidad
{
    public class CntAno
    {
        public int id { get; set; }
        public int id_comprobante { get; set; }
        public int ano_ano { get; set; }
        public bool ano_cerrado { get; set; }
        public string estado { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }


        public CnfUsuario usuario { get; set; }
        public CntComprobante comprobante { get; set; }


    }
}