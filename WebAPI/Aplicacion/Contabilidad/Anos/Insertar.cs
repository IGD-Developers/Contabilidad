namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;

public class InsertarAnoRequest : InsertarAnoModel, IRequest
{ }

public class InsertarAnoValidator : AbstractValidator<InsertarAnoRequest>
{
    public InsertarAnoValidator()
    {
        RuleFor(x => x.IdComprobante).NotEmpty();
        RuleFor(x => x.AnoAno).NotEmpty();
        RuleFor(x => x.AnoCerrado).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();
    }
}

public class InsertarAnoHandler : IRequestHandler<InsertarAnoRequest>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public InsertarAnoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task<Unit> Handle(InsertarAnoRequest request, CancellationToken cancellationToken)
    {

        //Como vamos a grabar primero el modelo y luego la entidad:
        var entidadDto = _mapper.Map<InsertarAnoModel, CntAno>(request);


        try
        {
            _context.cntAnos.Add(entidadDto);
            var respuesta = await _context.SaveChangesAsync();
            if (respuesta > 0)
            {
                return Unit.Value;
            }
            throw new Exception("No se ha realizado modificaciones a la base de datos");
        }
        catch (Exception ex)
        {

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

        // var ano = new CntAno
        // {
        //     IdComprobante = request.IdComprobante,
        //     AnoAno = request.AnoAno,
        //     AnoCerrado = request.AnoCerrado,
        //     ano_estado = request.ano_estado,
        //     IdUsuario = request.IdUsuario

        // };

        // try {
        //     _context.cntAnos.Add(ano);
        //     var respuesta = await _context.SaveChangesAsync();
        //     if( respuesta>0)
        //     {
        //         return Unit.Value;

        //     }
        //     throw new Exception("Error al insertar año");

        // } catch (SystemException) {

        //      throw new Exception("Error Inesperado al insertar año");

        // }

    }
}