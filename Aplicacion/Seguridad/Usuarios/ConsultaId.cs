using System.Threading;
using System.Threading.Tasks;
using Dominio.Configuracion;
using MediatR;
using Persistencia;

namespace Aplicacion.Seguridad;

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