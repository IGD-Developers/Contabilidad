using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.SeccionCiius;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.SeccionCiius;

public class ListarSeccionCiiusRequest : IRequest<List<SeccionCiiusModel>> { }

public class ListarSeccionCiiusHandler : IRequestHandler<ListarSeccionCiiusRequest, List<SeccionCiiusModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListarSeccionCiiusHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SeccionCiiusModel>> Handle(ListarSeccionCiiusRequest request, CancellationToken cancellationToken)
    {
        var listarSeccionCiius = await _context.CntSeccionCiius.ToListAsync();

        var listarSeccionCiiusModel = _mapper.Map<List<CntSeccionCiiu>, List<SeccionCiiusModel>>(listarSeccionCiius);

        return listarSeccionCiiusModel;
    }
}