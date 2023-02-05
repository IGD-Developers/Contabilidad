namespace ContabilidadWebAPI.Dominio.Configuracion;

public class CnfUsuario : IdentityUser
{
    //TODO:Id:85 COD:96	Otras actividades de servicios personales
    public int IdTercero { get; set; }
    public bool UsuEstado { get; set; }
    public bool UsuSupervisor { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    public CntTercero Tercero { get; set; }
    public ICollection<CntComprobante> UsuarioComprobantes { get; set; }
    public ICollection<CntTipoComprobante> UsuarioTipoComprobantes { get; set; }
    public ICollection<CntPuc> UsuarioPucs { get; set; }
    public ICollection<CntAno> UsuarioAnos { get; set; }
    public ICollection<CntMes> UsuarioMeses { get; set; }
    //public ICollection<CntLiquidaImpuesto> usuarioLiquidaImpuestos { get; set; }



}