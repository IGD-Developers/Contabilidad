using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class ListaCntExogenaConceptosRequest : IRequest<List<CntExogenaConcepto>>
{
}


public class ListaCntExogenaConceptosHandler : IRequestHandler<ListaCntExogenaConceptosRequest, List<CntExogenaConcepto>>
{

    private CntContext context;

    public ListaCntExogenaConceptosHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntExogenaConcepto>> Handle(ListaCntExogenaConceptosRequest request, CancellationToken cancellationToken)
    {
        var exogenaConceptos = await context.cntExogenaConceptos.ToListAsync();
        return exogenaConceptos;

    }
}