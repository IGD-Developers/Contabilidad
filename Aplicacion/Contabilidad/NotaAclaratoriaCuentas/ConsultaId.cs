using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.NotaAclaratoriaCuentas
{
    public class ConsultaId
    {
        public class ConsultarId : IRequest<CntNotaAclaratoriaCuenta>
        {

            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultarId, CntNotaAclaratoriaCuenta>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntNotaAclaratoriaCuenta> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var notaAclaratoriaCuenta = await context.cntNotaAclaratoriaCuentas.FindAsync(request.Id);
                return notaAclaratoriaCuenta;
            }
        }

    }
}