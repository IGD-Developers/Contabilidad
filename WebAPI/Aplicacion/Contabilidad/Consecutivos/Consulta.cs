using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;

public class Consulta

{
    public class ListaCntConsecutivos : IRequest<List<CntConsecutivo>>
    {

    }

    public class manejador : IRequestHandler<ListaCntConsecutivos, List<CntConsecutivo>>
    {

        private readonly CntContext context;

        public manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntConsecutivo>> Handle(ListaCntConsecutivos request, CancellationToken cancellationToken)
        {
            var consecutivos = await context.cntConsecutivos.ToListAsync();
            return consecutivos;


        }
    }


}