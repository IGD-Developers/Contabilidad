using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoCuentas
{
    public class Consulta
    {
        public class ListaCntTipoCuentas : IRequest<List<CntTipoCuenta>>
        {

        }

        public class Manejador : IRequestHandler<ListaCntTipoCuentas, List<CntTipoCuenta>>
        {
            private readonly CntContext context;

            public Manejador(CntContext _context)
            {
                context = _context;
            }

            public async Task<List<CntTipoCuenta>> Handle(ListaCntTipoCuentas request, CancellationToken cancellationToken)
            {
                var tipoCuentas = await context.cntTipoCuentas.ToListAsync();
                return tipoCuentas;

            }
        }



    }
}