using System;

namespace Dominio.Contabilidad;

public class CntUvt
{
    public int id { get; set; }
    public int uvt_ano { get; set; }
    public double uvt_valor { get; set; }
    public DateTime created_at { get; set; }
    public DateTime? updated_at { get; set; }
}