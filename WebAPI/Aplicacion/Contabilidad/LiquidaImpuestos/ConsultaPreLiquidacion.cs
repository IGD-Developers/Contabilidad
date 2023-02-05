namespace ContabilidadWebAPI.Aplicacion.Contabilidad.LiquidaImpuestos;


public class ConsultarPreLiquidacionRequest : FiltroGeneraImpuestosModel, IRequest<List<ListarDetallesPreLiquidacionImpuestoModel>>
{ }

public class ConsultaPreLiquidacionHandler : IRequestHandler<ConsultarPreLiquidacionRequest, List<ListarDetallesPreLiquidacionImpuestoModel>>
{
    private CntContext _context;
    private readonly IMapper _mapper;

    public ConsultaPreLiquidacionHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarDetallesPreLiquidacionImpuestoModel>> Handle(ConsultarPreLiquidacionRequest request, CancellationToken cancellationToken)
    {

        var entidad = await _context.cntEntidades
            .Where(e => e.Id == request.IdEntidad && e.IdTipoimpuesto == request.IdTipoimpuesto)
            .Select(e => new IdLiquidaImpuestoModel() { Id = e.Id })
            .FirstOrDefaultAsync();

        if (entidad == null)
        { throw new Exception("No se ha configurado correctamente la Entidad con su tipo de impuesto"); }

        var cuentaCierre = await _context.cntCuentaImpuestos
            .Where(ci => ci.IdTipoimpuesto == request.IdTipoimpuesto)
            .Select(ci => new IdLiquidaImpuestoModel() { Id = ci.IdPuc })
            .FirstOrDefaultAsync();

        if (cuentaCierre == null)
        { throw new Exception("No se ha configurado la contrapartida para el tipo de Impuesto"); }

        // request.FechaInicial = (request.FechaInicial == null) ? DateTime.Now : request.FechaInicial;
        // request.FechaFinal = (request.FechaFinal == null) ? DateTime.Now : request.FechaFinal;

        //===============================================
        //Revisar en el rango de fechas los comprobantes que no sean tipo LIM en Comprobante  
        //y con la relación de detalle extraer los registros marcados como "A"ctivos
        //de aquellos comprobantes que tienen cuentas con este tipo de impuesto. 
        //Revisar en cntPuc las cuentas que tienen el tipo de impuesto request.IdTipoimpuesto
        //Revisar los movimientos en detallecomprobante y extraer los movimientos que tienen incluidas esas cuentas
        //===============================================

        var entidadesDto = await _context.cntDetalleComprobantes
        .Include(d => d.Tercero)
        .Include(d => d.Puc)
        .Where(p => p.Puc.IdTipoimpuesto == request.IdTipoimpuesto)
        .Include(c => c.Comprobante)
        .Where(co => co.Comprobante.CcoFecha >= request.FechaInicial
                    && co.Comprobante.CcoFecha <= request.FechaFinal
                    && co.Comprobante.IdSucursal == request.IdSucursal
                    && co.Comprobante.Estado == "A")
        .Include(co => co.Comprobante)
        .ThenInclude(t => t.Usuario)
        .ThenInclude(tu => tu.Tercero)
        .Select(p => _mapper.Map<CntDetalleComprobante, ListarDetallesPreLiquidacionImpuestoModel>(p))
        .ToListAsync();

        return entidadesDto;


    }
}
