namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Generos;

public class ListaGenerosRequest : IRequest<List<GeneroModel>> { }

public class ListaGenerosHandler : IRequestHandler<ListaGenerosRequest, List<GeneroModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListaGenerosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GeneroModel>> Handle(ListaGenerosRequest request, CancellationToken cancellationToken)
    {
        var listaGeneros = await _context.CntGeneros.ToListAsync();
        var listaGenerosModel = _mapper.Map<List<CntGenero>, List<GeneroModel>>(listaGeneros);
        return listaGenerosModel;
    }
}