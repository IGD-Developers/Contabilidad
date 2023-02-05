namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;

public class ConsultarCentroCostoRequest : IdCentroCostoModel, IRequest<ListarCentroCostosModel>
{ }


public class ConsultarCentroCostoHandler : IRequestHandler<ConsultarCentroCostoRequest, ListarCentroCostosModel>
{

    private CntContext _context;
    private readonly IMapper _mapper;



    public ConsultarCentroCostoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarCentroCostosModel> Handle(ConsultarCentroCostoRequest request, CancellationToken cancellationToken)
    {
        var entidad = await _context.cntCentroCostos.FindAsync(request.Id);
        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CntCentroCosto, ListarCentroCostosModel>(entidad);
        return entidadDto;
    }
}