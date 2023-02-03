using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Anos;

namespace Aplicacion.Contabilidad.Anos
{
    public class ConsultaId
    {
        public class ConsultarId : IdAnoModel,IRequest<CntAno>
        { }

        public class Manejador : IRequestHandler<ConsultarId, CntAno>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntAno> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var ano = await context.cntAnos.FindAsync(request.Id);
                if (ano == null) {
                    throw new Exception("Registro no encontrado");
                };
                return ano;

            }
        }

    }
}