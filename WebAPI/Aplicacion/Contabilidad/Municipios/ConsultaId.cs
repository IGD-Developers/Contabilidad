namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Municipios;

public class ConsultarMunicipioRequest : IRequest<MunicipioModel>
{
    public int Id;
}

public class ConsultarMunicipioHandler : IRequestHandler<ConsultarMunicipioRequest, MunicipioModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarMunicipioHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MunicipioModel> Handle(ConsultarMunicipioRequest request, CancellationToken cancellationToken)
    {
        var consultaId = await _context.CntMunucipios.FindAsync(request.Id);

        if (consultaId == null)
        {
            throw new Exception("Municipio Consultado no Existe");
        }

        var consultaIdModel = _mapper.Map<CntMunicipio, MunicipioModel>(consultaId);
        return consultaIdModel;
    }
}