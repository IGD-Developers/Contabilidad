using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Contabilidad.Pucs
{
    /// <summary>
    /// Persistencia:Interface con los metodos a implementar que contienen la logica de negocios a usar en CRUD -DAPPER - Store Procedures.
    /// </summary>
    public interface IPucRepositorio
    {
         
         /// <summary>
        /// Persistencia:Obtiene la Data CntPuc - Dapper
        /// </summary>
        /// <returns> Objeto IEnumerable con la data de CntPuc</returns>
         Task<IEnumerable<PucRepositorioModel>> ObtenerLista();
         Task<PucRepositorioModel> ObtenerId(int Id);
         Task<int> Insertar(PucRepositorioModel data);
         Task<int> Actualiza(PucRepositorioModel data);
         Task<int> Elimina(int id);


    }
}