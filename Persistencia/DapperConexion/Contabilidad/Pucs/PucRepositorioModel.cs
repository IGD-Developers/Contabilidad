using System;

namespace Persistencia.DapperConexion.Contabilidad.Pucs;


    /// <summary>
    /// Data a retornar de la base de datos - SP-Dapper 
    /// </summary>     public class PucModelView
public class PucRepositorioModel
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int? IdPuctipo { get; set; }
    public int? IdTipocuenta { get; set; }
    public bool PacActiva { get; set; }
    public bool PacBase { get; set; }
    public bool PacAjusteniif { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string IdUsuario { get; set; }

}