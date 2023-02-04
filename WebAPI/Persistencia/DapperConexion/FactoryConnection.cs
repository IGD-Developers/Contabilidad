
using System.Data;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace ContabilidadWebAPI.Persistencia.DapperConexion;

public class FactoryConnection : IFactoryConnection
{

    private IDbConnection _connection;
    private readonly IOptions<ConexionConfiguracion> _configs;
    public FactoryConnection(IOptions<ConexionConfiguracion> configs)
    {
        _configs = configs;
    }
    public void CloseConnection()
    {
        if (_connection == null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }

    }


    /// <summary>
    /// Devuelve el objeto de conexion con la conexión abierta- Envuelto por Dapper
    /// </summary>
    public IDbConnection GetConnection()
    {
        //_connection representa la cadena de conexión
        if (_connection == null)
        {
            _connection = new MySqlConnection(_configs.Value.Conexion);
        }
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
        return _connection;



    }
}