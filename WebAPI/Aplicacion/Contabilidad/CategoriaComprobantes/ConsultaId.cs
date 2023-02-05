namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class ConsultarCategoriaComprobanteRequest : IdCategoriaModel, IRequest<ListarCategoriaComprobantesModel>
{ }

public class ConsultarCategoriaComprobanteHandler : IRequestHandler<ConsultarCategoriaComprobanteRequest, ListarCategoriaComprobantesModel>
{
    private CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarCategoriaComprobanteHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarCategoriaComprobantesModel> Handle(ConsultarCategoriaComprobanteRequest request, CancellationToken cancellationToken)
    {
        var entidad = await _context.cntCategoriaComprobantes
            .Include(c => c.CategoriaTipoComprobantes)
            .SingleOrDefaultAsync(i => i.Id == request.Id);
        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };

        var entidadDto = _mapper.Map<CntCategoriaComprobante, ListarCategoriaComprobantesModel>(entidad);

        return entidadDto;

    }
}