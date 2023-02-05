namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCiius;

public class ListarTipoCiiusRequest : IRequest<List<TipoCiiusModel>> { }

public class ListarTipoCiiusHandler : IRequestHandler<ListarTipoCiiusRequest, List<TipoCiiusModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListarTipoCiiusHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoCiiusModel>> Handle(ListarTipoCiiusRequest request, CancellationToken cancellationToken)
    {
        var listaTipoCiius = await _context.cntTipoCiius.ToListAsync();

        var listaTipoCiiusModel = _mapper.Map<List<CntTipoCiiu>, List<TipoCiiusModel>>(listaTipoCiius);

        return listaTipoCiiusModel;
    }
}