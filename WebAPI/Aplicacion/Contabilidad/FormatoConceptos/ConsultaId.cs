namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

public class ConsultarFormatoConceptoRequest : IRequest<CntFormatoConcepto>
{
    public int Id { get; set; }
}

public class ConsultarFormatoConceptoHandler : IRequestHandler<ConsultarFormatoConceptoRequest, CntFormatoConcepto>
{

    private readonly CntContext context;

    public ConsultarFormatoConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntFormatoConcepto> Handle(ConsultarFormatoConceptoRequest request, CancellationToken cancellationToken)
    {
        var formatoConcepto = await context.cntFormatoConceptos.FindAsync(request.Id);
        if (formatoConcepto == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return formatoConcepto;
    }
}