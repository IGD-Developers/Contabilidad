namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

//Lista de objetos tipo IRequest envolviendo una lista de tipo CntCategoriaComprobante
public class ListaCntCategoriaComprobantesRequest : IRequest<List<ListarCategoriaComprobantesModel>>
{
}


//Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera Clase declarada,
//el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante>
//Obliga a implementar  Interfaz.
// Requiere Constructor
public class ListaCntCategoriaComprobantesHandler : IRequestHandler<ListaCntCategoriaComprobantesRequest, List<ListarCategoriaComprobantesModel>>
{
    private CntContext _context;
    private readonly IMapper _mapper;

    public ListaCntCategoriaComprobantesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //La interfaz se autogenera -agregamos async
    //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 
    public async Task<List<ListarCategoriaComprobantesModel>> Handle(ListaCntCategoriaComprobantesRequest request, CancellationToken cancellationToken)
    {
        // El contexto devuelve desde el dbset

        var entidades = await _context.cntCategoriaComprobantes
        .Include(c => c.CategoriaTipoComprobantes)
        .ToListAsync();

        var entidadesDto = _mapper.Map<List<CntCategoriaComprobante>, List<ListarCategoriaComprobantesModel>>(entidades);

        return entidadesDto;

    }
}