using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class ConsultaId
{
    public class ConsultarId : IRequest<CntExogenaConcepto>
    {

        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntExogenaConcepto>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntExogenaConcepto> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var exogenaConcepto = await context.cntExogenaConceptos.FindAsync(request.Id);
            if (exogenaConcepto == null)
            {
                throw new Exception("Registro no encontrado");
            };
            return exogenaConcepto;
        }
    }

}