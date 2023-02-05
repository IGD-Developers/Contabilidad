namespace ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;

public class ConsultarEmpresaRequest : IdEmpresasModel, IRequest<ListarEmpresasModel>
{ }

public class ConsultarEmpresaHandler : IRequestHandler<ConsultarEmpresaRequest, ListarEmpresasModel>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public ConsultarEmpresaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarEmpresasModel> Handle(ConsultarEmpresaRequest request, CancellationToken cancellationToken)
    {


        var entidad = await _context.cnfEmpresas
        .Include(t => t.TerceroEmpresa)
        .SingleOrDefaultAsync(i => i.Id == request.Id);

        //.FindAsync(request.Id);

        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CnfEmpresa, ListarEmpresasModel>(entidad);
        return entidadDto;


        // return Empresa;

    }
}