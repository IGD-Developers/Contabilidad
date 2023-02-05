namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoComprobantes;

//Lista de objetos tipo IRequest envolviendo una lista de tipo CntTipoComprobante
public class ListaCntTipoComprobantesRequest : IRequest<List<ListarTipoComprobanteModel>>
{

}


//Clase ListaCntTipoComprobantesHandler que hereda de IRequestHandler. Obliga a implementar  Interfaz.
// Requiere Constructor
//Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantesRequest primera Clase declarada,
//el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante> 
public class ListaCntTipoComprobantesHandler : IRequestHandler<ListaCntTipoComprobantesRequest, List<ListarTipoComprobanteModel>>
{

    private CntContext _context;
    private readonly IMapper _mapper;



    public ListaCntTipoComprobantesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;


    }
    //La interfaz se autogenera -agregamos async
    //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 

    public async Task<List<ListarTipoComprobanteModel>> Handle(ListaCntTipoComprobantesRequest request, CancellationToken cancellationToken)
    {
        // El contexto devuelve desde el dbset
        var entidades = await _context.cntTipoComprobantes
        .Include(t => t.Categoria)
        .ToListAsync();

        var entidadesDto = _mapper.Map<List<CntTipoComprobante>, List<ListarTipoComprobanteModel>>(entidades);

        return entidadesDto;

    }
}