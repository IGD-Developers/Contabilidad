namespace ContabilidadWebAPI.Aplicacion.Contabilidad.SeccionCiius;

public class ConsultarSeccionCiiuRequest : IRequest<SeccionCiiusModel>
{
    public int Id;
}

public class ConsultarSeccionCiiuHandler : IRequestHandler<ConsultarSeccionCiiuRequest, SeccionCiiusModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarSeccionCiiuHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SeccionCiiusModel> Handle(ConsultarSeccionCiiuRequest request, CancellationToken cancellationToken)
    {
        var consultarId = await _context.CntSeccionCiius.FindAsync(request.Id);

        if (consultarId == null)
        {
            throw new Exception("SECCION CIIUS CONSULTADA NO EXISTE");
        }

        var consultarIdModel = _mapper.Map<CntSeccionCiiu, SeccionCiiusModel>(consultarId);
        return consultarIdModel;
    }
}