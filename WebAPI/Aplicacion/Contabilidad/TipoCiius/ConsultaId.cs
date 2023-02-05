namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCiius;

public class ConsultarTipoCiiuRequest : IRequest<TipoCiiusModel>
{
    public int Id;
}

public class ConsultarTipoCiiuHandler : IRequestHandler<ConsultarTipoCiiuRequest, TipoCiiusModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarTipoCiiuHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoCiiusModel> Handle(ConsultarTipoCiiuRequest request, CancellationToken cancellationToken)
    {
        var consultaId = await _context.cntTipoCiius.FindAsync(request.Id);

        if (consultaId == null)
        {
            throw new Exception("TIPO CIIUS CONSULTADO NO EXISTE");
        }

        var consultaIdModel = _mapper.Map<CntTipoCiiu, TipoCiiusModel>(consultaId);

        return consultaIdModel;
    }
}