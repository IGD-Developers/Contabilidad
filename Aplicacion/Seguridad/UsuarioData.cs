namespace Aplicacion.Seguridad;


/// <summary>Class <c>UsuarioData</c> Esta Clase representa 
/// la data que quiero devolver al cliente.</summary>
public class UsuarioData
{
     public int IdTercero { get; set; }
     public string  Token { get; set; }
     public string Email { get; set; }
     public string UserName { get; set; }

    
}