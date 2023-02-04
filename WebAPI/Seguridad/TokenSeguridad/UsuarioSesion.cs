using System.Linq;
using System.Security.Claims;
using ContabilidadWebAPI.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ContabilidadWebAPI.Seguridad.TokenSeguridad;

public class UsuarioSesion : IUsuarioSesion
{


    private readonly IHttpContextAccessor _httpContextAccesor;

    public UsuarioSesion(IHttpContextAccessor httpContextAccesor)
    {
        _httpContextAccesor = httpContextAccesor;
    }

    /// <summary>  
    ///   Mediante Linq, httpContextAccesor extrae el userName del Usuario en sesión. 
    ///</summary>
    ///<returns> Usuario en sesión </returns>


    public string ObtenerUsuarioSesion()
    {
        //Los claims son por ejemplo el Nombre, el rol, userName
        var userName = _httpContextAccesor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        return userName;
    }
}