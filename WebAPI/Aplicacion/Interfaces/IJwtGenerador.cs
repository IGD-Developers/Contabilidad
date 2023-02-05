namespace ContabilidadWebAPI.Aplicacion.Interfaces;

public interface IJwtGenerador
{
    string CrearToken(CnfUsuario Usuario);
}