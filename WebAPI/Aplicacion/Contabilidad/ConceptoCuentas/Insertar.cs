namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class InsertarConceptoCuentaRequest : IRequest
{

    public int IdExogenaconcepto { get; set; }
    public int IdPuc { get; set; }
    public int IdFormatocolumna { get; set; }
    public int IdTipooperacion { get; set; }
    public string Estado { get; set; }
}

public class InsertarConceptoCuentaHandler : IRequestHandler<InsertarConceptoCuentaRequest>
{
    private readonly CntContext context;

    public InsertarConceptoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarConceptoCuentaRequest request, CancellationToken cancellationToken)
    {
        var conceptoCuenta = new CntConceptoCuenta
        {
            IdExogenaconcepto = request.IdExogenaconcepto,
            IdPuc = request.IdPuc,
            IdFormatocolumna = request.IdFormatocolumna,
            IdTipooperacion = request.IdTipooperacion,
            Estado = request.Estado
        };
        context.cntConceptoCuentas.Add(conceptoCuenta);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error 112 al insertar conceptocuenta");
    }
}