namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Generos;

public class ConsultarGeneroRequest : IRequest<GeneroModel>
{
    public int Id;
}

public class ConsultarGeneroHandler : IRequestHandler<ConsultarGeneroRequest, GeneroModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarGeneroHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GeneroModel> Handle(ConsultarGeneroRequest request, CancellationToken cancellationToken)
    {
        var generoId = await _context.CntGeneros.FindAsync(request.Id);

        if (generoId == null)
        {
            throw new Exception("Genero Consultado no Existe");
        }

        var generoIdModel = _mapper.Map<CntGenero, GeneroModel>(generoId);

        return generoIdModel;
    }
}