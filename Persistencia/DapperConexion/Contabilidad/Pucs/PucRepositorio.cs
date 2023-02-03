using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Persistencia.DapperConexion.Contabilidad.Pucs;

/// <summary>
/// Persistencia:Inyectando IFactoryConnection implementa los metodos del crud para interactuar con la data de CntPuc
/// </summary>
public class PucRepositorio : IPucRepositorio

{

    private readonly IFactoryConnection _factoryConnection;

    public PucRepositorio(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    public Task<int> Actualiza(PucRepositorioModel data)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> Elimina(int id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> Insertar(PucRepositorioModel data)
    {
        var storeProcedure = "sp_insertarpuc";
        try
        {
            var connection = _factoryConnection.GetConnection();
            var resultado = await connection.ExecuteAsync(
                storeProcedure,
                new
                {
                    _codigo = data.codigo,
                    _nombre = data.nombre,
                    _id_puctipo = data.id_puctipo,
                    _id_tipocuenta = data.id_tipocuenta,
                    _pac_activa = data.pac_activa,
                    _pac_base = data.pac_base,
                    _pac_ajusteniif = data.pac_ajusteniif,
                    _id_usuario = data.id_usuario
                },
                commandType: CommandType.StoredProcedure);
            _factoryConnection.CloseConnection();

            return resultado;
        }
        catch (Exception e)
        {
            throw new Exception("Error al guardar registro", e);


        }
        finally
        {
        }

    }

    public Task<PucRepositorioModel> ObtenerId(int Id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<PucRepositorioModel>> ObtenerLista()
    {

        //Lista de resultados es de type IEnumerable porque eso es lo que devuelve la llamada al SP

        IEnumerable<PucRepositorioModel> pucList = null;
        //SP a ejecutar
        var storeProcedure = "sp_obtener_pucs";

        try
        {

            var connection = _factoryConnection.GetConnection();
            //La llamada siguiente retorna IEnumerable:
            pucList = await connection.QueryAsync<PucRepositorioModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);

        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            _factoryConnection.CloseConnection();

        }
        return pucList;


    }
}