namespace ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;

public class InsertarEmpresaRequest : InsertarEmpresasModel, IRequest
{ }

public class InsertarEmpresaValidator : AbstractValidator<InsertarEmpresaRequest>
{
    public InsertarEmpresaValidator()
    {
        RuleFor(x => x.Nit).NotEmpty();
        RuleFor(x => x.RazonSocial).NotEmpty();
    }
}

public class InsertarEmpresaHandler : IRequestHandler<InsertarEmpresaRequest>
{


    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public InsertarEmpresaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Unit> Handle(InsertarEmpresaRequest request, CancellationToken cancellationToken)
    {

        //Como vamos a grabar primero el modelo y luego la entidad:
        var empresaDto = _mapper.Map<InsertarEmpresasModel, CnfEmpresa>(request);


        //El mapeo va asi en el mappingprofile: CreateMap<InsertarEmpresasModel,CnfEmpresa>();

        try
        {
            await _context.cnfEmpresas.AddAsync(empresaDto);
            var respuesta = await _context.SaveChangesAsync();
            if (respuesta > 0)
            {
                return Unit.Value;
            }
            throw new Exception("No se ha realizado modificaciones a la base de datos");
        }
        catch (Exception ex)
        {

            //TODO Maria: LLave duplicada implementar validacion
            var sqlException = ex.InnerException;
            Console.WriteLine(sqlException);

            if (ex.GetBaseException().GetType() == typeof(MySqlException))
            {

                var sqlException1 = ex.InnerException as MySqlException;
                if (sqlException1.Number == 1062)
                {
                    Console.WriteLine("***************Llave duplicada *****************");

                }

            }
            //System.Console.WriteLine("***************Error de Grabación - Servidor No Disponible *****************");
            throw new Exception("Error al Insertar registro catch " + ex.Message);
        }


    }
}



