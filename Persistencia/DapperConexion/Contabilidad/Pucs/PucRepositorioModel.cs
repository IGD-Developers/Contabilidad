using System;

namespace Persistencia.DapperConexion.Contabilidad.Pucs;


    /// <summary>
    /// Data a retornar de la base de datos - SP-Dapper 
    /// </summary>     public class PucModelView
public class PucRepositorioModel
{
    public int id { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public int? id_puctipo { get; set; }
    public int? id_tipocuenta { get; set; }
    public bool pac_activa { get; set; }
    public bool pac_base { get; set; }
    public bool pac_ajusteniif { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public string id_usuario { get; set; }

}