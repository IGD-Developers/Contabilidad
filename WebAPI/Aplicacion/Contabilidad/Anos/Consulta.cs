namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;

public class ListaCntAnosRequest : IRequest<List<CntAno>>
{ }

public class ListaCntAnosHandler : IRequestHandler<ListaCntAnosRequest, List<CntAno>>
{

    private readonly CntContext context;

    public ListaCntAnosHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntAno>> Handle(ListaCntAnosRequest request, CancellationToken cancellationToken)
    {
        var listaAnos = await context.cntAnos.ToListAsync();
        return listaAnos;

    }
}
