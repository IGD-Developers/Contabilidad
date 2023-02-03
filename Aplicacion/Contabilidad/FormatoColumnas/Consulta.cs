using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.FormatoColumnas
{
    public class Consulta
    {

        public class ListaCntFormatoColumnas : IRequest<List<CntFormatoColumna>>
        {



        }

        public class Manejador : IRequestHandler<ListaCntFormatoColumnas, List<CntFormatoColumna>>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<List<CntFormatoColumna>> Handle(ListaCntFormatoColumnas request, CancellationToken cancellationToken)
            {
                var formatoColumnas = await context.cntFormatoColumnas.ToListAsync();
                return formatoColumnas;


            }
        }

    }
}