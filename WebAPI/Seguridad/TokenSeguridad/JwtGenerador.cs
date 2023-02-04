using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ContabilidadWebAPI.Aplicacion.Interfaces;
using ContabilidadWebAPI.Dominio.Configuracion;

namespace ContabilidadWebAPI.Seguridad.TokenSeguridad;

public class JwtGenerador : IJwtGenerador
{
    public string CrearToken(CnfUsuario Usuario)
    {
        //1-Lista de claims=data de Usuario a compartir con el cliente
        //2. paquete nuget System.Identity.Model.Token.jwt ultima version en royectoi seguridad
        //3-(Lista de claims registrados, lo que envie sea el Usuario.name)
        //4-crear las credenciales de acceso key=new SymetricSecurity
        //5-crear token
        //6-crear manejador del token
        //7-Devolver el token en string

        var claims = new List<Claim> {
         new Claim(JwtRegisteredClaimNames.NameId,Usuario.UserName)
     };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreto"));
        var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescripcion = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = System.DateTime.Now.AddDays(30),
            SigningCredentials = credenciales
        };

        var tokenManejador = new JwtSecurityTokenHandler();
        var token = tokenManejador.CreateToken(tokenDescripcion);
        return tokenManejador.WriteToken(token);
    }
}

