namespace Aplicacion.Seguridad;


/// <summary>Class <c>UsuarioData</c> Esta clase representa 
/// la data que quiero devolver al cliente.</summary>
public class UsuarioData
{
     public int id_tercero { get; set; }
     public string  Token { get; set; }
     public string Email { get; set; }
     public string UserName { get; set; }

    
}