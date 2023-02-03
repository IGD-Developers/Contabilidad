using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.ExogenaConceptos;

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
            if (exogenaConcepto == null) {  
                throw new Exception("Registro no encontrado");
            };                
            return exogenaConcepto;
        }
    }

}