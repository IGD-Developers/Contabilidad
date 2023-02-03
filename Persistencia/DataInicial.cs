using System.Linq;
using System.Threading.Tasks;
using Dominio.Configuracion;
using Microsoft.AspNetCore.Identity;

namespace Persistencia;

public class DataInicial
{
    public static async Task InsertarData(CntContext context, UserManager<CnfUsuario> usuarioManager) {

        if (!usuarioManager.Users.Any())
        {

            var usuario=new CnfUsuario{UserName="usuario",Email="usuario@gmail.com"};
            await usuarioManager.CreateAsync(usuario,"$Martha2014$");
        }
    }
}