using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.PucTipos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoCuentas;

namespace ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Pucs;

public class ListarPucModel
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int? IdPuctipo { get; set; }
    public int? IdTipocuenta { get; set; }
    public int? IdTipoimpuesto { get; set; }
    public bool PacActiva { get; set; }
    public bool PacBase { get; set; }
    public bool PacAjusteniif { get; set; }

    public string Clase { get; set; }
    public string Grupo { get; set; }
    public string Cuenta { get; set; }
    public string SubCuenta { get; set; }


    public PucTipoModel PucTipo { get; set; }
    public TipoCuentaModel TipoCuenta { get; set; }



}