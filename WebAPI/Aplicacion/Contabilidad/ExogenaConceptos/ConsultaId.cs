namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class ConsultarExogenaConceptoRequest : IRequest<CntExogenaConcepto>
{

    public int Id { get; set; }
}

public class ConsultarExogenaConceptoHandler : IRequestHandler<ConsultarExogenaConceptoRequest, CntExogenaConcepto>
{
    private readonly CntContext context;

    public ConsultarExogenaConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntExogenaConcepto> Handle(ConsultarExogenaConceptoRequest request, CancellationToken cancellationToken)
    {
        var exogenaConcepto = await context.cntExogenaConceptos.FindAsync(request.Id);
        if (exogenaConcepto == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return exogenaConcepto;
    }
}