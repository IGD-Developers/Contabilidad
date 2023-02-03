using System;
using System.Collections.Generic;
using Dominio.Configuracion;

namespace Dominio.Contabilidad
{
    public class CntPuc
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
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string id_usuario { get; set; }


        


        public CntPucTipo pucTipo { get; set; }
        public CntTipoCuenta tipoCuenta { get; set; }
        public CntTipoImpuesto tipoImpuesto { get; set; }
        public CnfUsuario usuario { get; set; }

        public ICollection<CntCuentaImpuesto> pucCuentaImpuestos { get; set; }

        public ICollection<CntDetalleComprobante> pucDetalleComprobantes { get; set; }
        public ICollection<CntNotaAclaratoriaCuenta> pucNotaAclaratoriaCuentas { get; set; }

        public ICollection<CntLiquidaImpuesto> pucLiquidaImpuestos { get; set; }
        public ICollection<CntNotaAclaratoria> pucNotaAclaratoria { get; set; }

    }

}