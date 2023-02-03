using System;
using Dominio.Configuracion;

namespace Dominio.Contabilidad;

public class CntAno
{
    public int Id { get; set; }
    public int IdComprobante { get; set; }
    public int AnoAno { get; set; }
    public bool AnoCerrado { get; set; }
    public string Estado { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }


    public CnfUsuario Usuario { get; set; }
    public CntComprobante Comprobante { get; set; }


}