using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Dominio.Configuracion;
//using Aplicacion.Configuracion.Usuarios;
using Aplicacion.Seguridad;
using Microsoft.AspNetCore.Authorization;

namespace ContabilidadWebAPI.Controllers.Configuracion;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : MiControllerBase
{
     //extender Nombre del endpoint con "login"
    // http://localhost:5000/api/Usuarios/login

    [HttpPost("login")]

    public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta parametros) {

        //Ahora invocamos directamente al manejador  de la Clase Login (que esta en Aplicacion.Seguridad) su public async Task<>
        // que nos returna el objeto UsuarioData dependiendo de si existe el Usuario:
        
        return await Mediator.Send(parametros);

    
    }
    // http://localhost:5000/api/Usuarios/registrar

    [HttpPost("registrar")]

    public async Task<ActionResult<UsuarioData>> Registrar(Registrar.Ejecuta parametros) {

        //Ahora invocamos directamente al manejador  de la Clase Ejecuta (que esta en Aplicacion.Seguridad) su public async Task<>
        // que nos returna el objeto UsuarioData :
        
        return await Mediator.Send(parametros);

    }
        // http://localhost:5000/api/Usuarios

    [HttpGet]
    public async Task<ActionResult<UsuarioData>> DevolverUsuario(){
        return await Mediator.Send(new UsuarioActual.Ejecuta());
    }
}