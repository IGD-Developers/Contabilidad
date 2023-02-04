using System.Collections.Generic;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Dominio.Configuracion;

public class CnfSucursal
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int IdEmpresa { get; set; }

    public CnfEmpresa Empresa { get; set; }
    public ICollection<CntComprobante> SucursalComprobantes { get; set; }
    public ICollection<CntConsecutivo> SucursalConsecutivo { get; set; }
}