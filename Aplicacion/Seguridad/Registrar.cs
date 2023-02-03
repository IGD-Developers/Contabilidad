using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Dominio.Configuracion;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad;

public class Registrar
{
    public class Ejecuta: IRequest<UsuarioData>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int id_tercero { get; set; }
    
    }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Nombre).NotEmpty();
            RuleFor(x=>x.Apellidos).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.Username).NotEmpty();
        }
    }

    public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
    {

        private readonly CntContext _context;
        private readonly UserManager<CnfUsuario> _userManager;
        private readonly IJwtGenerador _jwtGenerador;

        //UserManager<CnfUsuario> para poder aplicar  la seguridad Identity
        //IJwtGenerador para poder trabajar con los Tokens 
        public Manejador(CntContext context, UserManager<CnfUsuario> userManager, IJwtGenerador jwtGenerador)
        {
            _context = context;
            _userManager = userManager;
            _jwtGenerador = jwtGenerador;
        }

        public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            
            //x representa los registros dentro de la tabla users. Existe tiene un valor booleano
            var existe = await _context.Users.Where( x=> x.Email == request.Email).AnyAsync();
            if(existe)
            {
                 throw new Exception("Ya existe el Email1");
            }
            
            var existeUserName = await _context.Users.Where( x=> x.UserName == request.Username).AnyAsync();
            if(existeUserName)
            {
                 throw new Exception("Nombre de Usurio no disponible");

            }
            
            var usuario = new CnfUsuario {
               id_tercero= request.id_tercero,
               usu_estado =true,
               usu_supervisor =false,
               Email = request.Email,
               UserName=request.Username

            };

            var resultado= await _userManager.CreateAsync(usuario, request.Password);

            if (resultado.Succeeded)
            {
                return new UsuarioData {
                    id_tercero = usuario.id_tercero,
                    Token =_jwtGenerador.CrearToken(usuario),
                    UserName= usuario.UserName,
                    Email=usuario.Email

                };
            }

            throw new Exception("Ya existe el Email");

         }
    }
}