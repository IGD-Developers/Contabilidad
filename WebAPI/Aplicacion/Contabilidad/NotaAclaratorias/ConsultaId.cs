namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class ConsultarNotaAclaratoriaRequest : IRequest<ListarNotaAclaratoriaModel>
{
    public int Id { get; set; }
}

public class ConsultarNotaAclaratoriaHandler : IRequestHandler<ConsultarNotaAclaratoriaRequest, ListarNotaAclaratoriaModel>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarNotaAclaratoriaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarNotaAclaratoriaModel> Handle(ConsultarNotaAclaratoriaRequest request, CancellationToken cancellationToken)
    {
        var notaAclaratoria = await _context.cntNotaAclaratorias
        .Include(t => t.NotaAclaratoriaTipo)
        .Include(c => c.CntPuct)
        .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (notaAclaratoria == null)
        {
            throw new Exception("NOTA ACLARATORIA NO EXISTE");
        }

        var notaAclaratoriasModel = _mapper.Map<CntNotaAclaratoria, ListarNotaAclaratoriaModel>(notaAclaratoria);

        return notaAclaratoriasModel;
    }
}