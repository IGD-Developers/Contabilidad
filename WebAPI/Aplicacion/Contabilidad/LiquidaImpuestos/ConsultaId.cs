namespace ContabilidadWebAPI.Aplicacion.Contabilidad.LiquidaImpuestos;

public class ConsultarLiquidaImpuestoRequest : IdLiquidaImpuestoModel, IRequest<ListarLiquidaImpuestosModel>
{ }



public class ConsultarLiquidaImpuestoHandler : IRequestHandler<ConsultarLiquidaImpuestoRequest, ListarLiquidaImpuestosModel>
{
    private CntContext _context;

    private readonly IMapper _mapper;



    public ConsultarLiquidaImpuestoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarLiquidaImpuestosModel> Handle(ConsultarLiquidaImpuestoRequest request, CancellationToken cancellationToken)
    {

        var entidad = await _context.cntLiquidaImpuestos
        .Include(t => t.Tercero)
       .Include(ti => ti.TipoImpuesto)
       .Include(co => co.Comprobante)
       .ThenInclude(tipoc => tipoc.TipoComprobante)
       .Include(co => co.Comprobante)
       .ThenInclude(dt => dt.ComprobanteDetalleComprobantes)
       .Where(i => i.Id == request.Id)
        .Select(p => _mapper.Map<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>(p))
       .FirstOrDefaultAsync();

        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return entidad;
    }
}