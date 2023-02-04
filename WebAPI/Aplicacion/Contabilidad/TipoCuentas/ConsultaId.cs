using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;

public class ConsultaId
{

    public class ConsultarId : IRequest<CntTipoCuenta>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntTipoCuenta>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntTipoCuenta> Handle(ConsultarId request, CancellationToken cancellationToken)
        {

            var TipoCuenta = await context.cntTipoCuentas.FindAsync(request.Id);
            if (TipoCuenta == null)
            {
                throw new Exception("Registro no encontrado");
            };

            return TipoCuenta;
        }
    }

}