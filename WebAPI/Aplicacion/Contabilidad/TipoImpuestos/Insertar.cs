namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;

public class InsertarTipoImpuestoRequest : InsertarTipoImpuestosModel, IRequest
{ }

public class InsertarTipoImpuestoValidator : AbstractValidator<InsertarTipoImpuestoRequest>
{
    public InsertarTipoImpuestoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class InsertarTipoImpuestoHandler : IRequestHandler<InsertarTipoImpuestoRequest>
{

    private CntContext _context;

    private readonly IMapper _mapper;



    public InsertarTipoImpuestoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(InsertarTipoImpuestoRequest request, CancellationToken cancellationToken)
    {

        //Como vamos a grabar primero el modelo y luego la entidad:
        try
        {
            var entidadDto = _mapper.Map<InsertarTipoImpuestosModel, CntTipoImpuesto>(request);

            await _context.cntTipoImpuestos.AddAsync(entidadDto);
            var respuesta = await _context.SaveChangesAsync();
            if (respuesta > 0)
            {

                return Unit.Value;
            }
            throw new Exception("Error al insertar Registro");
        }
        catch (Exception ex)
        {
            //TODO: MARIA  Llave duplicada  CODIGO TIPOIMPUESTO Implementar
            throw new Exception("Error al Insertar registro catch " + ex.Message);

        }



    }
}