namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;

public class ConsultarResponsabilidadRequest : IRequest<ResponsabilidadModel>
{
    public int Id;
}

public class ConsultarResponsabilidadHandler : IRequestHandler<ConsultarResponsabilidadRequest, ResponsabilidadModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarResponsabilidadHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponsabilidadModel> Handle(ConsultarResponsabilidadRequest request, CancellationToken cancellationToken)
    {
        var consultarId = await _context.cntResponsabilidades.FindAsync(request.Id);

        if (consultarId == null)
        {
            throw new Exception("Responsabilidad Consultada no existe");
        }

        var consultarIdModel = _mapper.Map<CntResponsabilidad, ResponsabilidadModel>(consultarId);
        return consultarIdModel;
    }
}