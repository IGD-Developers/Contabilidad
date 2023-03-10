namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

public class ListaCntFormatoConceptosRequest : IRequest<List<CntFormatoConcepto>>
{
}


public class ListaCntFormatoConceptosHandler : IRequestHandler<ListaCntFormatoConceptosRequest, List<CntFormatoConcepto>>
{

    private readonly CntContext context;

    public ListaCntFormatoConceptosHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntFormatoConcepto>> Handle(ListaCntFormatoConceptosRequest request, CancellationToken cancellationToken)
    {

        var formatoConceptos = await context.cntFormatoConceptos.ToListAsync();
        return formatoConceptos;
    }
}