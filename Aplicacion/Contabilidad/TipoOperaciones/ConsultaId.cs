using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.TipoOperaciones
{
    public class ConsultaId
    {
        public class ConsultarId : IRequest<CntTipoOperacion>
        {

            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultarId, CntTipoOperacion>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntTipoOperacion> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var tipoOperacion = await context.cntTipoOperaciones.FindAsync(request.Id);
                if (tipoOperacion == null) {  
                        throw new Exception("Registro no encontrado");
                };                   
                return tipoOperacion;

            }
        }

    }
}