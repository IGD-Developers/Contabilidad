namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class ListaCntConceptoCuentasRequest : IRequest<List<CntConceptoCuenta>>
{

}


public class ListaCntConceptoCuentasHandler : IRequestHandler<ListaCntConceptoCuentasRequest, List<CntConceptoCuenta>>
{
    private readonly CntContext context;

    public ListaCntConceptoCuentasHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntConceptoCuenta>> Handle(ListaCntConceptoCuentasRequest request, CancellationToken cancellationToken)
    {
        var conceptoCuentas = await context.cntConceptoCuentas.ToListAsync();
        return conceptoCuentas;
    }
}