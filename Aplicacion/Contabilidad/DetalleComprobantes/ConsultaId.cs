using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.DetalleComprobantes
{
    public class ConsultaId
    {

        public class ConsultarId : IRequest<CntDetalleComprobante>
        {

            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultarId, CntDetalleComprobante>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntDetalleComprobante> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var detalleComprobante = await context.cntDetalleComprobantes.FindAsync(request.Id);
                if (detalleComprobante == null) {
                    throw new Exception("Registro no encontrado");
                };   
                return detalleComprobante;
            }
        }
    }
}