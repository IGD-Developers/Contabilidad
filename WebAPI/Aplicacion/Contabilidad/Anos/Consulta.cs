using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;

public class Consulta
{
    public class ListaCntAnos : IRequest<List<CntAno>>
    {

    }

    public class Manejador : IRequestHandler<ListaCntAnos, List<CntAno>>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntAno>> Handle(ListaCntAnos request, CancellationToken cancellationToken)
        {
            var listaAnos = await context.cntAnos.ToListAsync();
            return listaAnos;

        }
    }

}