using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Seguridad.Usuarios;

public class ConsultarCnfUsuarioIdRequest : IRequest<CnfUsuario>
{
    public int Id { get; set; }
}

public class ConsultarCnfUsuarioIdHandler : IRequestHandler<ConsultarCnfUsuarioIdRequest, CnfUsuario>
{

    private readonly CntContext context;

    public ConsultarCnfUsuarioIdHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CnfUsuario> Handle(ConsultarCnfUsuarioIdRequest request, CancellationToken cancellationToken)
    {
        var Usuario = await context.cnfUsuarios.FindAsync(request.Id);
        return Usuario;
    }
}