using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Seguridad.Usuarios;

public class ConsultaId
{
    public class ConsultarId : IRequest<CnfUsuario>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CnfUsuario>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CnfUsuario> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var Usuario = await context.cnfUsuarios.FindAsync(request.Id);
            return Usuario;
        }
    }

}