namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;

public class ConsultarBancoRequest : IdBancoModel, IRequest<ListarBancosModel>
{ }

public class ConsultarBancoHandler : IRequestHandler<ConsultarBancoRequest, ListarBancosModel>
{
    private CntContext _context;

    private readonly IMapper _mapper;



    public ConsultarBancoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarBancosModel> Handle(ConsultarBancoRequest request, CancellationToken cancellationToken)
    {


        var entidad = await _context.cntBancos
        .SingleOrDefaultAsync(i => i.Id == request.Id);

        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CntBanco, ListarBancosModel>(entidad);
        return entidadDto;


    }
}