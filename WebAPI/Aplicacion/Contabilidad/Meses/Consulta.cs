namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

public class ListaCntMesesRequest : IRequest<List<CntMes>>
{

}

public class ListaCntMesesHandler : IRequestHandler<ListaCntMesesRequest, List<CntMes>>
{
    private CntContext context;

    public ListaCntMesesHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntMes>> Handle(ListaCntMesesRequest request, CancellationToken cancellationToken)
    {

        var listaMeses = await context.cntMeses.ToListAsync();
        return listaMeses;

    }
}