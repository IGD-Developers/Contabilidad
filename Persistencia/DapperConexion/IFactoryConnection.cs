using System.Data;

namespace Persistencia.DapperConexion
{

    /// <summary>
    /// Interface con los metodos para cerrar y obtener el objeto de conexión -Dapper
    /// </summary>
    public interface IFactoryConnection
    {
    /// <summary>
    /// Cerrar todas las conexiones abiertas -Dapper
    /// </summary>
        void CloseConnection();

    /// <summary>
    /// Devuelve el objeto de conexion - Envuelto por Dapper
    /// </summary>
        IDbConnection GetConnection();

    }
}