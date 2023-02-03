using System.Collections.Generic;
using Dominio.Contabilidad;

namespace Dominio.Configuracion
{
    public class CnfEmpresa
    {
        public int id { get; set; }
        public string nit { get; set; }
        public string razon_social { get; set; }
        public int? id_tercero_gerente { get; set; }
         public CntTercero terceroEmpresa {get;set;}

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
        public ICollection<CnfSucursal> empresaSucursales { get; set; }
       


        
        } 



    }
