using System.Collections.Generic;
using Dominio.Contabilidad;

namespace Dominio.Configuracion
{
    public class CnfEmpresa
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public int? IdTerceroGerente { get; set; }
        public CntTercero TerceroEmpresa { get; set; }
        public ICollection<CnfSucursal> EmpresaSucursales { get; set; }

        // public string nombregerente { get{
        //     if(this.id_tercero_gerente!=null)
        //     {
        //         string pa = terceroEmpresa.ter_priapellido ?? "c";
        //         string sa = terceroEmpresa.ter_segapellido ?? "c";
        //         string pn = terceroEmpresa.ter_prinombre ?? "c";
        //         string sn = terceroEmpresa.ter_segnombre ?? "c";

        //        return (pa + " " + sa + " "+ pn + " " + sn);

        //     }
        //     return "No Registrado ";
        // }
        // }

    }
}
