namespace ContabilidadWebAPI.Aplicacion.Configuracion.Sucursales;

public class ConsultarSucursalRequest : IdSucursalModel, IRequest<ListarSucursalModel>
{ }

public class ConsultarSucursalHandler : IRequestHandler<ConsultarSucursalRequest, ListarSucursalModel>
{

    private CntContext _context;

    private readonly IMapper _mapper;



    public ConsultarSucursalHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }


    public async Task<ListarSucursalModel> Handle(ConsultarSucursalRequest request, CancellationToken cancellationToken)
    {

        var entidad = await _context.cnfSucursales
        .Include(e => e.Empresa)
        .SingleOrDefaultAsync(i => i.Id == request.Id);


        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CnfSucursal, ListarSucursalModel>(entidad);

        return entidadDto;


    }
}