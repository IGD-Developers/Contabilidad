using System.Collections.Generic;
using Dominio.Contabilidad;

namespace Dominio.Configuracion;

public class CnfEmpresa
{
    public int Id { get; set; }
    public string Nit { get; set; }
    public string RazonSocial { get; set; }
    public int? IdTerceroGerente { get; set; }
    public CntTercero TerceroEmpresa { get; set; }
    public ICollection<CnfSucursal> EmpresaSucursales { get; set; }

    // public string nombregerente { get{
    //     if(this.IdTerceroGerente!=null)
    //     {
    //         string pa = terceroEmpresa.TerPriapellido ?? "c";
    //         string sa = terceroEmpresa.TerSegapellido ?? "c";
    //         string pn = terceroEmpresa.TerPrinombre ?? "c";
    //         string sn = terceroEmpresa.TerSegnombre ?? "c";

    //        return (pa + " " + sa + " "+ pn + " " + sn);

    //     }
    //     return "No Registrado ";
    // }
    // }

}
