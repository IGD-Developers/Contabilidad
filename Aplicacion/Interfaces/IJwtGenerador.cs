using Dominio.Configuracion;

namespace Aplicacion.Interfaces;

public interface IJwtGenerador
{
    string CrearToken(CnfUsuario usuario) ;
}