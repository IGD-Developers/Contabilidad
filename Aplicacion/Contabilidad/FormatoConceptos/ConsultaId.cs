using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.FormatoConceptos;

public class ConsultaId
{
    public class ConsultarId : IRequest<CntFormatoConcepto>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntFormatoConcepto>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntFormatoConcepto> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var formatoConcepto = await context.cntFormatoConceptos.FindAsync(request.Id);
           if (formatoConcepto == null) {  
                throw new Exception("Registro no encontrado");
            };                

            return formatoConcepto;
        }
    }
}