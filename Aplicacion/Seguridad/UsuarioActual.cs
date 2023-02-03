using MediatR;
using Dominio.Configuracion;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Aplicacion.Interfaces;

namespace Aplicacion.Seguridad
{
    public class UsuarioActual
    {

        public class Ejecuta : IRequest<UsuarioData>
        {


        }
        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            //Necesito inyectar tres clases
            //UserManager
            //IJwtGenerador
            //IUsarioSesion 

            private readonly UserManager<CnfUsuario> _userManager;
            private readonly IJwtGenerador  _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;

            public Manejador(UserManager<CnfUsuario> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //El userManager busca a un usuario en la base de datos con ese userName y lo va a devolver 
                var usuario =  await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
                return new UsuarioData{
                    id_tercero=usuario.id_tercero,
                    Token= _jwtGenerador.CrearToken(usuario),
                    Email = usuario.Email,
                    UserName= usuario.UserName  
                };
            }
        }



    }
}