using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.PucTipos
{
    public class Consulta
    {

        public class ListaCntPucTipos : IRequest<List<CntPucTipo>>
        {


        }

        public class Manejador : IRequestHandler<ListaCntPucTipos, List<CntPucTipo>>
        {
            private readonly CntContext context;
            public Manejador(CntContext _context)
            {
                context = _context;
            }

            public async Task<List<CntPucTipo>> Handle(ListaCntPucTipos request, CancellationToken cancellationToken)
            {
                var pucTipos = await context.cntPucTipos.ToListAsync();
                return pucTipos;

            }
        }


    }

}
