using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Configuracion;
using Microsoft.AspNetCore.Identity;

namespace ContabilidadWebAPI.Persistencia;

public class DataInicial
{
    public static async Task InsertarData(CntContext context, UserManager<CnfUsuario> usuarioManager)
    {

        if (!usuarioManager.Users.Any())
        {

            var Usuario = new CnfUsuario { UserName = "Usuario", Email = "Usuario@gmail.com" };
            await usuarioManager.CreateAsync(Usuario, "$Martha2014$");
        }
    }
}