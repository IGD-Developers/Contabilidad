using System;
using Dominio.Configuracion;

namespace Dominio.Contabilidad
{
    public class CntMes
    {
        public int id { get; set; }
        public int mes_ano { get; set; }
        public int mes_mes { get; set; }
        public bool mes_cerrado { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }

        public CnfUsuario usuario { get; set; }

    }
}