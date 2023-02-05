namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Ciius;

public class ConsultarCiiuRequest : IRequest<CiiuModel>
{
    public int Id { get; set; }
}

public class ConsultarCiiuHandler : IRequestHandler<ConsultarCiiuRequest, CiiuModel>
{
    private readonly CntContext _cntContext;
    private readonly IMapper _mapper;

    public ConsultarCiiuHandler(CntContext cntContext, IMapper mapper)
    {
        _cntContext = cntContext;
        _mapper = mapper;
    }

    public async Task<CiiuModel> Handle(ConsultarCiiuRequest request, CancellationToken cancellationToken)
    {
        var ciiusId = await _cntContext.CntCiius
        .Include(x => x.CiiuSeccionCiiu)
        .Include(x => x.CiiuTipoCiiu)
        .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (ciiusId == null)
        {
            throw new Exception("CIIUS Consultado no Existe");
        }

        var ciiusIdModel = _mapper.Map<CntCiiu, CiiuModel>(ciiusId);
        return ciiusIdModel;
    }
}