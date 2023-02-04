using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;

public class Consulta
{
    public class ListaUvts : IRequest<List<CntUvt>>
    {

    }

    public class Manejador : IRequestHandler<ListaUvts, List<CntUvt>>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntUvt>> Handle(ListaUvts request, CancellationToken cancellationToken)
        {
            var uvts = await context.cntUvts.ToListAsync();
            return uvts;

        }
    }

}