using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.PucTipos;

public class ListaCntPucTiposRequest : IRequest<List<CntPucTipo>>
{


}

public class ListaCntPucTiposHandler : IRequestHandler<ListaCntPucTiposRequest, List<CntPucTipo>>
{
    private readonly CntContext context;
    public ListaCntPucTiposHandler(CntContext _context)
    {
        context = _context;
    }

    public async Task<List<CntPucTipo>> Handle(ListaCntPucTiposRequest request, CancellationToken cancellationToken)
    {
        var pucTipos = await context.cntPucTipos.ToListAsync();
        return pucTipos;

    }
}
