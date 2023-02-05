namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;

public class InsertarCentroCostoRequest : InsertarCentroCostosModel, IRequest
{ }

public class InsertarCentroCostoValidator : IRequestHandler<InsertarCentroCostoRequest>
{
    private CntContext _context;
    private readonly IMapper _mapper;



    public InsertarCentroCostoValidator(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public class InsertarCentroCostoHandler : AbstractValidator<InsertarCentroCostoRequest>
    {
        public InsertarCentroCostoHandler()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();

        }
    }

    public async Task<Unit> Handle(InsertarCentroCostoRequest request, CancellationToken cancellationToken)
    {

        var entidadDto = _mapper.Map<InsertarCentroCostosModel, CntCentroCosto>(request);


        try
        {
            _context.cntCentroCostos.Add(entidadDto);

            var respuesta = await _context.SaveChangesAsync();
            if (respuesta > 0)
            {
                return Unit.Value;
            }
            throw new Exception("Error al insertar CentroCosto");
            //TODO: MARIA  Llave duplicada  CODIGO CentroCosto Implementar
        }
        catch (Exception ex)
        {
            throw new Exception("Error al Insertar registro catch " + ex.Message);

        }
    }
}