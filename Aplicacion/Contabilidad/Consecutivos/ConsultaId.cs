using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.Consecutivos;

public class ConsultaId
{

    public class ConsultarId : IRequest<CntConsecutivo>
    {
        public int Id { get; set; }
    }
    public class Manejador : IRequestHandler<ConsultarId, CntConsecutivo>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntConsecutivo> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consecutivo = await context.cntConsecutivos.FindAsync(request.Id);
            if (consecutivo == null) {
                throw new Exception("Registro no encontrado");
            };    
            return consecutivo;
        }
    }
}