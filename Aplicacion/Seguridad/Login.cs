using MediatR;
using Persistencia;
using Dominio.Configuracion;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using Aplicacion.Interfaces;

namespace Aplicacion.Seguridad
{
    public class Login

    {
         /// <summary>Class <c>Ejecuta</c> Esta clase devuelve
        /// la Entidad UsuarioData.</summary>
        //clase cabecera de tipo <UsuarioData> que se va a llamar desde el webAPI

        public class Ejecuta: IRequest<UsuarioData> {

            public string Password { get; set; }
            public string Email { get; set; }

        }

        public class EjecutaValidacion:AbstractValidator<Ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x=>x.Email).NotEmpty();
                RuleFor(x=>x.Password).NotEmpty();


            }


        }


        public class Manejador: IRequestHandler<Ejecuta,UsuarioData> 
        //Clase Manejador que representa la logica en si.
        //Recibe dos pmts: 1-Ejecuta(para que ingresesn los valores de Email y password)
        //y el 2-Tipo de entidad que va a trabajar sobre la cual va a hacer la transaccion que es UsuarioData
        {
            private readonly UserManager<CnfUsuario> _userManager;
            private readonly SignInManager<CnfUsuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;

            public Manejador( UserManager<CnfUsuario> userManager, SignInManager<CnfUsuario> signInManager, IJwtGenerador jwtGenerador)
             // Para trabajar la logica de loginDebemos inyectar en el constructor de manejador 
            //dos objetos:UserManager, SignInManager que vienen de CoreIdentity y referencian 
            //a la base de datos para hacer la comparacion del Email y password que entran como pmts

            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador =jwtGenerador;
            }

            
        public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var usuario= await _userManager.FindByEmailAsync(request.Email);
                if (usuario==null){
                    throw new Exception("Error  Login");

                }

                var resultado=await _signInManager.CheckPasswordSignInAsync(usuario,request.Password,false);
                if (resultado.Succeeded){
                    return new UsuarioData{
                        id_tercero =usuario.id_tercero,
                        Token= _jwtGenerador.CrearToken(usuario),
                        Email= usuario.Email ,
                        UserName = usuario.UserName
                    };
                }
                throw new Exception("Error Login Usuario");

                
            }
           

             
        }


    



    }
}