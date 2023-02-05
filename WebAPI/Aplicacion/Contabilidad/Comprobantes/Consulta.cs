using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

public class ListaCntComprobantesRequest : IRequest<List<ListarComprobantesModel>>
{

}

public class ListaCntComprobantesHandler : IRequestHandler<ListaCntComprobantesRequest, List<ListarComprobantesModel>>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public ListaCntComprobantesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;



    }

    public async Task<List<ListarComprobantesModel>> Handle(ListaCntComprobantesRequest request, CancellationToken cancellationToken)
    {
        // El contexto devuelve el dbset

        var comprobantes = await _context.cntComprobantes
        .Include(t => t.TipoComprobante)
        .ThenInclude(ctg => ctg.Categoria)
        .Include(s => s.Sucursal)
        .Include(u => u.Usuario)
        .Include(d => d.ComprobanteDetalleComprobantes)
        .ToListAsync();

        var comprobantesDto = _mapper.Map<List<CntComprobante>, List<ListarComprobantesModel>>(comprobantes);

        return comprobantesDto;

    }
}