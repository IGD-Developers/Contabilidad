using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Anos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;

public class ConsultaId
{
    public class ConsultarId : IdAnoModel, IRequest<CntAno>
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
            if (ano == null)
            {
                throw new Exception("Registro no encontrado");
            };
            return ano;

        }
    }

}