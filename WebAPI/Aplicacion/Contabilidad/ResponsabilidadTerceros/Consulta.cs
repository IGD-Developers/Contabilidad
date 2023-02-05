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