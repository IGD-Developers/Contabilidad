namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;

public class ListaCntTipoImpuestosRequest : IRequest<List<ListarTipoImpuestosModel>>
{ }

public class ListaCntTipoImpuestosHandler : IRequestHandler<ListaCntTipoImpuestosRequest, List<ListarTipoImpuestosModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;
    public ListaCntTipoImpuestosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarTipoImpuestosModel>> Handle(ListaCntTipoImpuestosRequest request, CancellationToken cancellationToken)
    {

        var entidades = await _context.cntTipoImpuestos.ToListAsync();
        var entidadesDto = _mapper.Map<List<CntTipoImpuesto>, List<ListarTipoImpuestosModel>>(entidades);
        return entidadesDto;


    }
}