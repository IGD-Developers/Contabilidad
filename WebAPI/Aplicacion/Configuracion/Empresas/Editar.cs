namespace ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;

public class EditarEmpresaRequest : EditarEmpresasModel, IRequest
{


}

public class EditarEmpresaValidator : AbstractValidator<EditarEmpresaRequest>
{
    public EditarEmpresaValidator()
    {
        RuleFor(x => x.Nit).NotEmpty();
        RuleFor(x => x.RazonSocial).NotEmpty();
        //RuleFor(x=>x.IdTerceroGerente).NotEmpty();

    }
}

public class EditarEmpresaHandler : IRequestHandler<EditarEmpresaRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public EditarEmpresaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;



    }


    public async Task<Unit> Handle(EditarEmpresaRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var Empresa = await _context.cnfEmpresas.FindAsync(request.Id);
            if (Empresa == null)
            {
                throw new Exception("Empresa no encontrada");
            };

            request.IdTerceroGerente ??= Empresa.IdTerceroGerente;

            //Como vamos a grabar primero el modelo y luego la entidad:
            var empresasDto = _mapper.Map<EditarEmpresasModel, CnfEmpresa>(request, Empresa);

            //El mapeo va asi en el mappingprofile: CreateMap<EditarEmpresasModel,CnfEmpresa>();


            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }
            //Ojo 00 Vista con mensaje

            throw new Exception("No se realizaron modificaciones al registro");

        }
        catch (Exception ex)
        {
            throw new Exception("Error al editar registro catch " + ex.Message);
        }

    }


}

