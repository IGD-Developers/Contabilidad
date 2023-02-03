using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.TipoCuentas;

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

            var tipoCuenta = await context.cntTipoCuentas.FindAsync(request.Id);
            if (tipoCuenta == null) {  
                    throw new Exception("Registro no encontrado");
            };                   

            return tipoCuenta;
        }
    }

}