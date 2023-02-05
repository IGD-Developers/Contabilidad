namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class InsertarExogenaConceptoRequest : IRequest
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
}


public class InsertarExogenaConceptoValidator : AbstractValidator<InsertarExogenaConceptoRequest>
{
    public InsertarExogenaConceptoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();


    }
}
public class InsertarExogenaConceptoHandler : IRequestHandler<InsertarExogenaConceptoRequest>
{

    private readonly CntContext context;

    public InsertarExogenaConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarExogenaConceptoRequest request, CancellationToken cancellationToken)
    {

        var exogenaConcepto = new CntExogenaConcepto
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Estado = request.Estado

        };
        context.cntExogenaConceptos.Add(exogenaConcepto);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al insertar ExogenaConcepto");
    }
}