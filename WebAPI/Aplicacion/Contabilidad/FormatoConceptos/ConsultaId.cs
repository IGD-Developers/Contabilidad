using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

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
            if (formatoConcepto == null)
            {
                throw new Exception("Registro no encontrado");
            };

            return formatoConcepto;
        }
    }
}