using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

public class Consulta
{
    public class ListaCntMeses : IRequest<List<CntMes>>
    {

    }

    public class Manejador : IRequestHandler<ListaCntMeses, List<CntMes>>
    {
        private CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntMes>> Handle(ListaCntMeses request, CancellationToken cancellationToken)
        {

            var listaMeses = await context.cntMeses.ToListAsync();
            return listaMeses;

        }
    }

}