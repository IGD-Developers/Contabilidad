using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.ExogenaFormatos
{
    public class Consulta
    {
        public class ListaCntExogenaFormatos : IRequest<List<CntExogenaFormato>>
        {

        }

        public class Manejador : IRequestHandler<ListaCntExogenaFormatos, List<CntExogenaFormato>>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<List<CntExogenaFormato>> Handle(ListaCntExogenaFormatos request, CancellationToken cancellationToken)
            {

                var exogenaFormatos = await context.cntExogenaFormatos.ToListAsync();
                return exogenaFormatos;
            }
        }




    }
}