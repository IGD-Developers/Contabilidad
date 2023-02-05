namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;

public class InsertarEntidadRequest : InsertarEntidadModel, IRequest
{ }


public class InsertarEntidadValidator : AbstractValidator<InsertarEntidadRequest>
{
    public InsertarEntidadValidator()
    {
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.IdTipoimpuesto).NotEmpty();

    }
}


public class InsertarEntidadHandler : IRequestHandler<InsertarEntidadRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public InsertarEntidadHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(InsertarEntidadRequest request, CancellationToken cancellationToken)
    {



        var entidadDto = _mapper.Map<InsertarEntidadModel, CntEntidad>(request);


        _context.cntEntidades.Add(entidadDto);
        try
        {
            var respuesta = await _context.SaveChangesAsync();
            if (respuesta > 0)
            {
                return Unit.Value;
            }
            throw new Exception("Error al insertar Entidad");
        }
        catch (Exception ex)
        {
            throw new Exception("Error al Insertar registro catch " + ex.Message);


        }
    }
}