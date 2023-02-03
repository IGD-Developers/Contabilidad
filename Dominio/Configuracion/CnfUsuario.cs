using System;
using System.Collections.Generic;
using Dominio.Contabilidad;
using Microsoft.AspNetCore.Identity;

namespace Dominio.Configuracion;

public class CnfUsuario:IdentityUser
{
    //TODO:ID:85 COD:96	Otras actividades de servicios personales
    public int id_tercero { get; set; }
    public bool usu_estado { get; set; }
    public bool usu_supervisor { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? update_at { get; set; }

    public CntTercero tercero {get;set;}
    public ICollection<CntComprobante> usuarioComprobantes { get; set; }
    public ICollection<CntTipoComprobante> usuarioTipoComprobantes { get; set; }
    public ICollection<CntPuc> usuarioPucs { get; set; }
    public ICollection<CntAno> usuarioAnos { get; set; }
    public ICollection<CntMes> usuarioMeses { get; set; }
    //public ICollection<CntLiquidaImpuesto> usuarioLiquidaImpuestos { get; set; }



}