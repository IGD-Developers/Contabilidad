namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

public class InsertarFormatoColumnaRequest : IRequest
{

    public int IdExogenaformato { get; set; }
    public string FcoColumna { get; set; }
    public string FcoCampo { get; set; }
    public string FcoTipo { get; set; }
}

public class InsertarFormatoColumnaValidator : AbstractValidator<InsertarFormatoColumnaRequest>
{
    public InsertarFormatoColumnaValidator()
    {
        RuleFor(x => x.IdExogenaformato).NotEmpty();
        RuleFor(x => x.FcoColumna).NotEmpty();
        RuleFor(x => x.FcoCampo).NotEmpty();
        RuleFor(x => x.FcoTipo).NotEmpty();

    }
}


public class InsertarFormatoColumnaHandler : IRequestHandler<InsertarFormatoColumnaRequest>
{

    private readonly CntContext context;

    public InsertarFormatoColumnaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarFormatoColumnaRequest request, CancellationToken cancellationToken)
    {
        var formatoColumna = new CntFormatoColumna
        {
            IdExogenaformato = request.IdExogenaformato,
            FcoColumna = request.FcoColumna,
            FcoCampo = request.FcoCampo,
            FcoTipo = request.FcoTipo
        };
        context.cntFormatoColumnas.Add(formatoColumna);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error 113 al insertar Formato Columna");
    }
}