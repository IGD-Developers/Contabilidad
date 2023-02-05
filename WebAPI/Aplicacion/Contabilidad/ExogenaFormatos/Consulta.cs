namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;

public class ListaCntExogenaFormatosRequest : IRequest<List<CntExogenaFormato>>
{

}

public class ListaCntExogenaFormatosHandler : IRequestHandler<ListaCntExogenaFormatosRequest, List<CntExogenaFormato>>
{

    private readonly CntContext context;

    public ListaCntExogenaFormatosHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntExogenaFormato>> Handle(ListaCntExogenaFormatosRequest request, CancellationToken cancellationToken)
    {

        var exogenaFormatos = await context.cntExogenaFormatos.ToListAsync();
        return exogenaFormatos;
    }
}