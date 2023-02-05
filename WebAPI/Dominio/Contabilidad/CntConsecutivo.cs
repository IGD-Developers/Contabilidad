namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntConsecutivo
{
    public int Id { get; set; }
    public int IdTipocomprobante { get; set; }
    public int IdSucursal { get; set; }
    public string CoAno { get; set; }
    public string CoMes { get; set; }
    public int CoConsecutivo { get; set; }

    public CntTipoComprobante TipoComprobante { get; set; }
    public CnfSucursal Sucursal { get; set; }
}