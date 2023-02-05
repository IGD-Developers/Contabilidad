namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public class ListarTercerosRequest : IRequest<List<ListarTerceroModel>> { }

public class ListarTercerosHandler : IRequestHandler<ListarTercerosRequest, List<ListarTerceroModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListarTercerosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarTerceroModel>> Handle(ListarTercerosRequest request, CancellationToken cancellationToken)
    {
        var terceros = await _context.CntTerceros
        .Include(g => g.Genero)
        .Include(d => d.Documentos)
        .Include(m => m.Municipio).ThenInclude(z => z.Departamento)
        .Include(r => r.Regimen)
        .Include(p => p.TipoPersona)
        .Include(c => c.Ciiu).ThenInclude(z => z.CiiuSeccionCiiu)
        .Include(c => c.Ciiu).ThenInclude(z => z.CiiuTipoCiiu)
        .Include(r => r.ResponsabilidadTerceros).ThenInclude(z => z.Responsabilidad)
        .Include(e => e.EntidadTerceros).ThenInclude(z => z.TipoImpuesto)
        .ToListAsync();

        var tercerosModel = _mapper.Map<List<CntTercero>, List<ListarTerceroModel>>(terceros);


        return tercerosModel;
    }
}