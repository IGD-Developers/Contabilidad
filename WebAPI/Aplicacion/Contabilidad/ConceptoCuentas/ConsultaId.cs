using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class ConsultaId
{
    public class ConsultarId : IRequest<CntConceptoCuenta>
    {
        public int Id { get; set; }

    }

    public class Manejador : IRequestHandler<ConsultarId, CntConceptoCuenta>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntConceptoCuenta> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var conceptoCuenta = await context.cntConceptoCuentas.FindAsync(request.Id);
            if (conceptoCuenta == null)
            {
                throw new Exception("Registro no encontrado");
            };
            return conceptoCuenta;

        }
    }

}