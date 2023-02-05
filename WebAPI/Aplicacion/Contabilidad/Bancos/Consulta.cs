using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Bancos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;

public class ListaCntBancosRequest : IRequest<List<ListarBancosModel>>
{

}

public class ListaCntBancosHandler : IRequestHandler<ListaCntBancosRequest, List<ListarBancosModel>>
{
    private CntContext _context;
    private readonly IMapper _mapper;

    public ListaCntBancosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarBancosModel>> Handle(ListaCntBancosRequest request, CancellationToken cancellationToken)
    {

        var entidades = await _context.cntBancos.ToListAsync();
        var entidadesDto = _mapper.Map<List<CntBanco>, List<ListarBancosModel>>(entidades);
        return entidadesDto;
    }
}