using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class Consulta
{
    public class ListaCntExogenaConceptos : IRequest<List<CntExogenaConcepto>>
    {



    }


    public class Manejador : IRequestHandler<ListaCntExogenaConceptos, List<CntExogenaConcepto>>
    {

        private CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntExogenaConcepto>> Handle(ListaCntExogenaConceptos request, CancellationToken cancellationToken)
        {
            var exogenaConceptos = await context.cntExogenaConceptos.ToListAsync();
            return exogenaConceptos;

        }
    }

}