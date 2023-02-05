namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CuentaImpuestos;

public class ConsultarCuentaImpuestoRequest : IdCuentaImpuestoModel, IRequest<ListarCuentaImpuestosModel>
{ }

public class ConsultarCuentaImpuestoHandler : IRequestHandler<ConsultarCuentaImpuestoRequest, ListarCuentaImpuestosModel>
{
    private CntContext _context;

    private readonly IMapper _mapper;



    public ConsultarCuentaImpuestoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarCuentaImpuestosModel> Handle(ConsultarCuentaImpuestoRequest request, CancellationToken cancellationToken)
    {

        var entidadDto = await _context.cntCuentaImpuestos
                                .Include(p => p.Puc)
                                .Include(p => p.TipoImpuesto)
                                .Where(p => p.Id == request.Id)
                                .Select(p => _mapper.Map<CntCuentaImpuesto, ListarCuentaImpuestosModel>(p))
                                .SingleOrDefaultAsync();


        if (entidadDto == null)
        {
            throw new Exception("Registro no encontrado");
        };
        //var entidadDto = _mapper.Map<CntCuentaImpuesto, ListarCuentaImpuestosModel>(entidad);
        return entidadDto;


    }
}