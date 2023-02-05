namespace ContabilidadWebAPI.Aplicacion.Configuracion.Sucursales;


//Lista de objetos tipo IRequest envolviendo una lista de tipo CntCategoriaComprobante
public class ListaCnfSucursalesRequest : IRequest<List<ListarSucursalModel>>
{ }

//Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera Clase declarada,
//el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante>

public class ListaCnfSucursalesHandler : IRequestHandler<ListaCnfSucursalesRequest, List<ListarSucursalModel>>
{
    private CntContext _context;
    private readonly IMapper _mapper;



    public ListaCnfSucursalesHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }


    //La interfaz se autogenera -agregamos async
    //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 
    public async Task<List<ListarSucursalModel>> Handle(ListaCnfSucursalesRequest request, CancellationToken cancellationToken)
    {
        // El contexto devuelve desde el dbset

        var entidades = await _context.cnfSucursales
        .Include(e => e.Empresa)
        .ToListAsync();

        var entidadesDto = _mapper.Map<List<CnfSucursal>, List<ListarSucursalModel>>(entidades);

        return entidadesDto;

    }
}