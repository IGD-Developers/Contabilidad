using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ResponsabilidadTerceros;

public class ListarResponsabilidadesTerceroRequest : IRequest<List<ResponsabilidadTerceroModel>> { }

public class ListarResponsabilidadesTerceroHandler : IRequestHandler<ListarResponsabilidadesTerceroRequest, List<ResponsabilidadTerceroModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListarResponsabilidadesTerceroHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ResponsabilidadTerceroModel>> Handle(ListarResponsabilidadesTerceroRequest request, CancellationToken cancellationToken)
    {
        var listar = await _context.cntResponsabilidadTerceros
        .Include(r => r.Responsabilidad)
        .ToListAsync();

        var ListarModel = _mapper.Map<List<CntResponsabilidadTer>, List<ResponsabilidadTerceroModel>>(listar);
        return ListarModel;
    }
}