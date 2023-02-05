namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class ListaCntNotaAclaratoriaTiposRequest : IRequest<List<NotaAclaratoriaTipoModel>>
{ }

public class ListaCntNotaAclaratoriaTiposHandler : IRequestHandler<ListaCntNotaAclaratoriaTiposRequest, List<NotaAclaratoriaTipoModel>>
{
    private CntContext _context;
    private IMapper _mapper;

    public ListaCntNotaAclaratoriaTiposHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<NotaAclaratoriaTipoModel>> Handle(ListaCntNotaAclaratoriaTiposRequest request, CancellationToken cancellationToken)
    {
        var notaAclaratoriaTipos = await _context.cntNotaAclaratoriaTipos.ToListAsync();

        var notaAclaratoriasTiposModel = _mapper.Map<List<CntNotaAclaratoriaTipo>, List<NotaAclaratoriaTipoModel>>(notaAclaratoriaTipos);

        return notaAclaratoriasTiposModel;

    }
}