using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.NotaAclaratoriaTipos
{
    public class ConsultaId
    {
        public class ConsultarId : IRequest<CntNotaAclaratoriaTipo>
        {

            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultarId, CntNotaAclaratoriaTipo>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntNotaAclaratoriaTipo> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var notaAclaratoriaTipo = await context.cntNotaAclaratoriaTipos.FindAsync(request.Id);
                return notaAclaratoriaTipo;

            }
        }

    }
}