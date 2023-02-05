using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;

public class ListaCntEntidadesRequest : IRequest<List<ListarEntidadesModel>>
{ }

public class ListaCntEntidadesHandler : IRequestHandler<ListaCntEntidadesRequest, List<ListarEntidadesModel>>
{

    private CntContext _context;
    private readonly IMapper _mapper;



    public ListaCntEntidadesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarEntidadesModel>> Handle(ListaCntEntidadesRequest request, CancellationToken cancellationToken)
    {
        //TODO: MARIA- Validar existe Tercero, existe tipoimpuesto
        var entidades = await _context.cntEntidades
        .Include(t => t.Tercero)
        .Include(i => i.TipoImpuesto)
        .ToListAsync();
        var entidadesDto = _mapper.Map<List<CntEntidad>, List<ListarEntidadesModel>>(entidades);

        return entidadesDto;
    }
}