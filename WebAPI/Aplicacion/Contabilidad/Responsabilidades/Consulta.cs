namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;

public class ListarResponsabilidadesRequest : IRequest<List<ResponsabilidadModel>> { }

public class ListarResponsabilidadesHandler : IRequestHandler<ListarResponsabilidadesRequest, List<ResponsabilidadModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListarResponsabilidadesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ResponsabilidadModel>> Handle(ListarResponsabilidadesRequest request, CancellationToken cancellationToken)
    {
        var responsabilidades = await _context.cntResponsabilidades.ToListAsync();
        var responsabilidadesModel = _mapper.Map<List<CntResponsabilidad>, List<ResponsabilidadModel>>(responsabilidades);

        return responsabilidadesModel;
    }


}