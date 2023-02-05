namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;

public class ListaUvtsRequest : IRequest<List<CntUvt>>
{

}

public class ListaUvtsHandler : IRequestHandler<ListaUvtsRequest, List<CntUvt>>
{
    private readonly CntContext context;

    public ListaUvtsHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntUvt>> Handle(ListaUvtsRequest request, CancellationToken cancellationToken)
    {
        var uvts = await context.cntUvts.ToListAsync();
        return uvts;

    }
}