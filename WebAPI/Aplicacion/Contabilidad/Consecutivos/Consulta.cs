namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;

public class ListaCntConsecutivosRequest : IRequest<List<CntConsecutivo>>
{

}

public class ListaCntConsecutivosHandler : IRequestHandler<ListaCntConsecutivosRequest, List<CntConsecutivo>>
{

    private readonly CntContext context;

    public ListaCntConsecutivosHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntConsecutivo>> Handle(ListaCntConsecutivosRequest request, CancellationToken cancellationToken)
    {
        var consecutivos = await context.cntConsecutivos.ToListAsync();
        return consecutivos;
    }
}