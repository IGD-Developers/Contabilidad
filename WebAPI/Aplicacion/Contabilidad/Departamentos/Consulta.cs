namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Departamentos;

public class ListaDepartamentosRequest : IRequest<List<DepartamentosModel>> { }

public class ListaDepartamentosHandler : IRequestHandler<ListaDepartamentosRequest, List<DepartamentosModel>>
{
    public readonly CntContext _context;
    public readonly IMapper _mapper;
    public ListaDepartamentosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;


    }

    public async Task<List<DepartamentosModel>> Handle(ListaDepartamentosRequest request, CancellationToken cancellationToken)
    {
        var departamentos = await _context.CntDepartamentos.ToListAsync();
        var DepartamentosModel = _mapper.Map<List<CntDepartamento>, List<DepartamentosModel>>(departamentos);
        return DepartamentosModel;
    }
}